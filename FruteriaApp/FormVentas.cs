namespace FruteriaApp;

// Pantalla de registro de ventas: se eligen productos y kilos, se van
// añadiendo a un carrito y al confirmar se envía la venta a la API
// (que es quien descuenta el stock).
public partial class FormVentas : Form
{
    private readonly ApiClient api;

    public FormVentas(ApiClient api)
    {
        InitializeComponent();
        this.api = api;
    }

    private async void FormVentas_Load(object sender, EventArgs e)
    {
        await CargarProductos();
    }

    // Rellena el ComboBox con los productos de la API.
    // DisplayMember indica qué propiedad del Producto se ve en la lista.
    private async Task CargarProductos()
    {
        try
        {
            cmbProductos.DataSource = await api.ObtenerProductosAsync();
            cmbProductos.DisplayMember = "Nombre";
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido conectar con la API.\n" + ex.Message, "Error");
        }
    }

    private void btnAnadir_Click(object sender, EventArgs e)
    {
        Producto producto = cmbProductos.SelectedItem as Producto;
        double kilos = (double)nudKilos.Value;

        if (producto == null)
        {
            MessageBox.Show("Elige un producto.");
            return;
        }
        if (kilos <= 0)
        {
            MessageBox.Show("Indica cuántos kilos.");
            return;
        }

        // Se añade una fila al carrito: id, nombre, kilos, precio/kg y subtotal
        double subtotal = Math.Round(kilos * producto.PrecioKg, 2);
        dgvCarrito.Rows.Add(producto.Id, producto.Nombre, kilos, producto.PrecioKg, subtotal);
        CalcularTotal();
    }

    // CellValueChanged se ejecuta cuando cambia una celda del carrito
    // (por ejemplo si el usuario modifica a mano los kilos de una fila).
    private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // Solo interesa cuando cambia la columna de kilos (e.RowIndex = -1 es la cabecera)
        if (e.RowIndex < 0 || dgvCarrito.Columns[e.ColumnIndex].Name != "colKilos")
            return;

        DataGridViewRow fila = dgvCarrito.Rows[e.RowIndex];
        double kilos = LeerNumero(fila.Cells["colKilos"].Value);
        double precio = LeerNumero(fila.Cells["colPrecio"].Value);
        fila.Cells["colSubtotal"].Value = Math.Round(kilos * precio, 2);

        CalcularTotal();
    }

    // Suma los subtotales de todas las filas y lo muestra en el Label
    private void CalcularTotal()
    {
        double total = 0;
        foreach (DataGridViewRow fila in dgvCarrito.Rows)
        {
            total += LeerNumero(fila.Cells["colSubtotal"].Value);
        }
        lblTotal.Text = $"Total: {total:0.00} €";
    }

    // Convierte el valor de una celda a número. Si el usuario escribe algo
    // que no es un número (por ejemplo letras) devuelve 0 en vez de fallar.
    private double LeerNumero(object valor)
    {
        double.TryParse(Convert.ToString(valor), out double numero);
        return numero;
    }

    private async void btnConfirmar_Click(object sender, EventArgs e)
    {
        if (dgvCarrito.Rows.Count == 0)
        {
            MessageBox.Show("El carrito está vacío.");
            return;
        }

        // Se construye la venta con una línea por cada fila del carrito
        NuevaVenta venta = new NuevaVenta();
        foreach (DataGridViewRow fila in dgvCarrito.Rows)
        {
            venta.Lineas.Add(new LineaVenta
            {
                ProductoId = (int)fila.Cells["colId"].Value,
                Kilos = LeerNumero(fila.Cells["colKilos"].Value)
            });
        }

        try
        {
            // La API comprueba el stock, lo descuenta y guarda la venta
            await api.RegistrarVentaAsync(venta);
            MessageBox.Show("Venta registrada. " + lblTotal.Text);

            // Se vacía el carrito y se recargan los productos (su stock ha cambiado)
            dgvCarrito.Rows.Clear();
            CalcularTotal();
            await CargarProductos();
        }
        catch (Exception ex)
        {
            // Por ejemplo, si no hay stock suficiente la API devuelve un error con el motivo
            MessageBox.Show("No se ha podido registrar la venta.\n" + ex.Message, "Error");
        }
    }
}
