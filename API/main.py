# API REST de la Frutería hecha con FastAPI.
# Los productos y las ventas se guardan en el archivo datos.json.
# Cada petición lee el archivo, hace el cambio y, si ha cambiado algo, lo vuelve a escribir.
#
# Para arrancarla (con el venv activado, dentro de la carpeta API):
#     uvicorn main:app --reload
# Documentación automática para probarla: http://127.0.0.1:8000/docs

import json
from datetime import datetime
from pathlib import Path

from fastapi import FastAPI, HTTPException
from pydantic import BaseModel

# Objeto principal de la API. Los decoradores @app.get, @app.post... le añaden rutas.
app = FastAPI()


# ---------------------------------------------------------------------------
# MODELOS
# Definen qué campos tiene cada dato. FastAPI los usa para leer y comprobar
# el JSON que llega en las peticiones.
# ---------------------------------------------------------------------------

class Producto(BaseModel):
    id: int = 0          # Al crear un producto la API le asigna el id ella sola
    nombre: str
    categoria: str
    precioKg: float
    stockKg: float


class LineaVenta(BaseModel):
    # Una línea del carrito: qué producto y cuántos kilos
    productoId: int
    kilos: float


class NuevaVenta(BaseModel):
    # Lo que envía la aplicación al confirmar una venta: la lista de líneas del carrito
    lineas: list[LineaVenta]


# ---------------------------------------------------------------------------
# ARCHIVO JSON
# El archivo tiene esta forma: {"productos": [...], "ventas": [...]}
# Cada producto y cada venta es un diccionario de Python.
# ---------------------------------------------------------------------------

# Ruta del archivo: siempre junto a este main.py, se arranque desde donde se arranque
ARCHIVO_DATOS = Path(__file__).parent / "datos.json"


def leer_datos():
    """Lee datos.json y devuelve su contenido como diccionario."""
    with open(ARCHIVO_DATOS, "r", encoding="utf-8") as f:
        return json.load(f)


def guardar_datos(datos):
    """Escribe el diccionario en datos.json."""
    with open(ARCHIVO_DATOS, "w", encoding="utf-8") as f:
        # ensure_ascii=False para que las tildes se guarden tal cual; indent=2 para que se lea bien
        json.dump(datos, f, ensure_ascii=False, indent=2)


def buscar_producto(datos, id: int):
    """Devuelve el producto con ese id, o None si no existe."""
    for p in datos["productos"]:
        if p["id"] == id:
            return p
    return None


# Si todavía no existe datos.json, se crea con estos productos al arrancar la API
if not ARCHIVO_DATOS.exists():
    guardar_datos({
        "productos": [
            {"id": 1, "nombre": "Manzana", "categoria": "Fruta", "precioKg": 2.5, "stockKg": 40},
            {"id": 2, "nombre": "Plátano", "categoria": "Fruta", "precioKg": 1.9, "stockKg": 25},
            {"id": 3, "nombre": "Naranja", "categoria": "Fruta", "precioKg": 1.6, "stockKg": 4},
            {"id": 4, "nombre": "Tomate", "categoria": "Verdura", "precioKg": 2.2, "stockKg": 30},
            {"id": 5, "nombre": "Lechuga", "categoria": "Verdura", "precioKg": 1.2, "stockKg": 3},
        ],
        "ventas": [],
    })


# ---------------------------------------------------------------------------
# ENDPOINTS DE PRODUCTOS (CRUD)
# ---------------------------------------------------------------------------

@app.get("/productos")
def listar_productos():
    datos = leer_datos()
    return datos["productos"]


@app.post("/productos")
def crear_producto(producto: Producto):
    datos = leer_datos()

    # El nuevo id es el id más alto que exista + 1 (o 1 si no hay productos)
    if len(datos["productos"]) > 0:
        producto.id = max(p["id"] for p in datos["productos"]) + 1
    else:
        producto.id = 1

    # model_dump() convierte el Producto en un diccionario para poder guardarlo en el JSON
    datos["productos"].append(producto.model_dump())
    guardar_datos(datos)
    return producto


@app.put("/productos/{id}")
def actualizar_producto(id: int, producto: Producto):
    datos = leer_datos()
    for i, p in enumerate(datos["productos"]):
        if p["id"] == id:
            producto.id = id          # Se mantiene el id de la URL
            datos["productos"][i] = producto.model_dump()
            guardar_datos(datos)
            return producto
    # 404 = "no encontrado". La aplicación WinForms recibirá este error.
    raise HTTPException(status_code=404, detail="Producto no encontrado")


@app.delete("/productos/{id}")
def borrar_producto(id: int):
    datos = leer_datos()
    producto = buscar_producto(datos, id)
    if producto is None:
        raise HTTPException(status_code=404, detail="Producto no encontrado")
    datos["productos"].remove(producto)
    guardar_datos(datos)
    return {"ok": True}


# ---------------------------------------------------------------------------
# ENDPOINTS DE VENTAS
# ---------------------------------------------------------------------------

@app.get("/ventas")
def listar_ventas():
    datos = leer_datos()
    return datos["ventas"]


@app.post("/ventas")
def registrar_venta(nueva_venta: NuevaVenta):
    if len(nueva_venta.lineas) == 0:
        raise HTTPException(status_code=400, detail="La venta no tiene productos")

    datos = leer_datos()

    # 1) Primero se comprueban TODAS las líneas. Si alguna falla no se guarda nada,
    #    así nunca queda una venta a medias.
    for linea in nueva_venta.lineas:
        producto = buscar_producto(datos, linea.productoId)
        if producto is None:
            raise HTTPException(status_code=404, detail=f"No existe el producto {linea.productoId}")
        if linea.kilos <= 0:
            raise HTTPException(status_code=400, detail="Los kilos deben ser mayores que 0")
        if linea.kilos > producto["stockKg"]:
            raise HTTPException(status_code=400, detail=f"No hay stock suficiente de {producto['nombre']}")

    # 2) Todo correcto: se descuenta el stock y se calcula el importe de cada línea
    lineas_guardadas = []
    total = 0
    for linea in nueva_venta.lineas:
        producto = buscar_producto(datos, linea.productoId)
        producto["stockKg"] = round(producto["stockKg"] - linea.kilos, 2)
        subtotal = round(linea.kilos * producto["precioKg"], 2)
        total += subtotal
        lineas_guardadas.append({
            "productoId": producto["id"],
            "nombre": producto["nombre"],
            "kilos": linea.kilos,
            "precioKg": producto["precioKg"],
            "subtotal": subtotal,
        })

    # 3) Se añade la venta y se guarda el archivo (con la venta y el stock nuevo)
    venta = {
        "id": len(datos["ventas"]) + 1,
        "fecha": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
        "lineas": lineas_guardadas,
        "total": round(total, 2),
    }
    datos["ventas"].append(venta)
    guardar_datos(datos)
    return venta
