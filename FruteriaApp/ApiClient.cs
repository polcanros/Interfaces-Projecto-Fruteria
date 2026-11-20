using System.Net.Http.Json;

namespace FruteriaApp;

// ---------------------------------------------------------------------------
// MODELOS: clases con los mismos campos que los datos de la API.
// En el JSON los nombres van en minúscula ("precioKg") y aquí en mayúscula
// ("PrecioKg"): .NET hace esa conversión automáticamente.
// ---------------------------------------------------------------------------

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Categoria { get; set; } = "";
    public double PrecioKg { get; set; }
    public double StockKg { get; set; }
}

// Una línea del carrito: qué producto y cuántos kilos
public class LineaVenta
{
    public int ProductoId { get; set; }
    public double Kilos { get; set; }
}

// Lo que se envía a POST /ventas al confirmar una venta
public class NuevaVenta
{
    public List<LineaVenta> Lineas { get; set; } = new List<LineaVenta>();
}

// ---------------------------------------------------------------------------
// API CLIENT: se encarga de TODA la comunicación con la API.
// Los formularios no hacen peticiones HTTP directamente: llaman a estos métodos.
// Así la parte visual queda separada de la parte de comunicación.
//
// Los métodos son "async" porque una petición por red tarda un poco;
// con "await" la ventana no se queda congelada mientras se espera la respuesta.
// ---------------------------------------------------------------------------
public class ApiClient
{
    // HttpClient es el objeto de .NET que hace las peticiones HTTP.
    // BaseAddress es la dirección donde está funcionando la API de FastAPI.
    private readonly HttpClient http = new HttpClient
    {
        BaseAddress = new Uri("http://127.0.0.1:8000/")
    };

    // GET /productos -> lista de productos (el JSON se convierte solo en List<Producto>)
    public async Task<List<Producto>> ObtenerProductosAsync()
    {
        List<Producto> productos = await http.GetFromJsonAsync<List<Producto>>("productos");
        return productos ?? new List<Producto>();
    }

    // POST /productos -> crea un producto (el objeto se envía convertido a JSON)
    public async Task CrearProductoAsync(Producto producto)
    {
        HttpResponseMessage respuesta = await http.PostAsJsonAsync("productos", producto);
        await ComprobarRespuesta(respuesta);
    }

    // PUT /productos/{id} -> modifica un producto
    public async Task ActualizarProductoAsync(int id, Producto producto)
    {
        HttpResponseMessage respuesta = await http.PutAsJsonAsync($"productos/{id}", producto);
        await ComprobarRespuesta(respuesta);
    }

    // DELETE /productos/{id} -> borra un producto
    public async Task EliminarProductoAsync(int id)
    {
        HttpResponseMessage respuesta = await http.DeleteAsync($"productos/{id}");
        await ComprobarRespuesta(respuesta);
    }

    // POST /ventas -> registra la venta; la API descuenta el stock
    public async Task RegistrarVentaAsync(NuevaVenta venta)
    {
        HttpResponseMessage respuesta = await http.PostAsJsonAsync("ventas", venta);
        await ComprobarRespuesta(respuesta);
    }

    // Si la API responde con un error (404, 400...), lanza una excepción con el
    // mensaje que ha enviado la API, para que el formulario lo muestre al usuario.
    private static async Task ComprobarRespuesta(HttpResponseMessage respuesta)
    {
        if (!respuesta.IsSuccessStatusCode)
        {
            string mensaje = await respuesta.Content.ReadAsStringAsync();
            throw new Exception(mensaje);
        }
    }
}
