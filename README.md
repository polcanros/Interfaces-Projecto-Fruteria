# Frutería: API REST (FastAPI) + aplicación WinForms

Sistema cliente-servidor para gestionar una frutería:

```
WinForms (cliente)  →  API FastAPI (servidor)  →  datos.json
```

## Estructura

| Carpeta / archivo | Qué contiene |
|---|---|
| `API/main.py` | La API: CRUD de productos y registro de ventas |
| `API/requirements.txt` | Librerías de Python necesarias |
| `API/datos.json` | Productos y ventas guardados. Se crea solo al arrancar la API |
| `FruteriaApp/` | La aplicación de escritorio en C# WinForms |
| `Fruteria.slnx` | Solución para abrir la aplicación en Visual Studio |
| `Como_ejecutar.pdf` | Documento con los pasos para ejecutar los dos proyectos |

## Endpoints de la API

| Método | Ruta | Qué hace |
|---|---|---|
| GET | `/productos` | Lista de productos |
| POST | `/productos` | Crea un producto |
| PUT | `/productos/{id}` | Modifica un producto |
| DELETE | `/productos/{id}` | Elimina un producto |
| POST | `/ventas` | Registra una venta y descuenta el stock |
| GET | `/ventas` | Lista de ventas realizadas |

## Pantallas de la aplicación

- **Menú**: abre las demás pantallas. Todas usan el mismo `ApiClient`.
- **Catálogo de productos**: tabla con los productos, botones Refrescar / Nuevo / Editar / Eliminar, buscador por nombre y filtro por categoría.
- **Control de stock**: tabla con los productos, filtro "Solo stock bajo" y filas en rojo para el stock crítico.
- **Registro de ventas**: se elige producto y kilos, se añade al carrito, se ve el total y se confirma la venta.

## Cómo ejecutarlo

También está explicado en `Como_ejecutar.pdf`.

### 1. Descargar el proyecto de GitHub

Abrir una terminal (PowerShell) en la carpeta donde se quiera guardar el proyecto, por ejemplo el Escritorio:

```powershell
cd $HOME\Desktop
git clone https://github.com/polcanros/Interfaces-Projecto-Fruteria.git
cd Interfaces-Projecto-Fruteria
```

Sin Git también se puede descargar: en https://github.com/polcanros/Interfaces-Projecto-Fruteria, botón **Code** → **Download ZIP**, y después descomprimir el ZIP.

### 2. Crear y activar el venv (solo la primera vez)

La carpeta `venv` no se sube a GitHub, por eso hay que crearla:

```powershell
cd API
python -m venv venv
venv\Scripts\activate
pip install -r requirements.txt
```

Si se ha activado bien, al principio de la línea de la terminal aparece `(venv)`.

### 3. Ejecutar la API

**¿Por qué se usa Uvicorn?** FastAPI solo sirve para escribir la API (las rutas, los modelos y la lógica), pero por sí solo no puede recibir peticiones por la red. Uvicorn es el servidor: abre la dirección `http://127.0.0.1:8000`, recibe las peticiones de la aplicación WinForms, se las pasa a FastAPI y devuelve la respuesta. Sin Uvicorn la API no se puede ejecutar.

En la misma terminal (dentro de la carpeta `API` y con `(venv)` activado):

```powershell
uvicorn main:app --reload
```

Cuando aparezca `Uvicorn running on http://127.0.0.1:8000` la API ya está funcionando. La primera vez también se crea el archivo `datos.json` con los productos.
**No cerrar esta terminal** mientras se use la aplicación.

### 4. Ejecutar la aplicación WinForms

La API tiene que estar arrancada antes (paso 3).

- **Con Visual Studio**: abrir `Fruteria.slnx` y pulsar **▶ FruteriaApp** (o F5).
- **Sin Visual Studio**: en una segunda terminal, en la carpeta principal del proyecto (la que tiene `Fruteria.slnx`):

```powershell
dotnet run --project FruteriaApp
```

### Las siguientes veces

El venv ya está creado, así que solo hay que hacer esto:

```powershell
# En la carpeta API
venv\Scripts\activate
uvicorn main:app --reload
```

Y después abrir `Fruteria.slnx` con Visual Studio y pulsar **▶**.