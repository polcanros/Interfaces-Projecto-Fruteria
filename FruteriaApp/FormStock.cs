namespace FruteriaApp;

// Pantalla de control de stock: lista los productos, permite ver solo
// los que tienen poco stock y pinta en rojo los que están en nivel crítico.
public partial class FormStock : Form
{
    // Un producto tiene stock bajo (crítico) si le quedan estos kilos o menos
    private const double STOCK_BAJO = 5;

    private readonly ApiClient api;
    private List<Producto> productos = new List<Producto>();

    public FormStock(ApiClient api)
    {
        InitializeComponent();
        this.api = api;
    }

    private async void FormStock_Load(object sender, EventArgs e)
    {
        await CargarProductos();
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        await CargarProductos();
    }

    private async Task CargarProductos()
    {
        try
        {
            productos = await api.ObtenerProductosAsync();
            MostrarProductos();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido conectar con la API.\n" + ex.Message, "Error");
        }
    }

    // Si la casilla "Solo stock bajo" está marcada, solo se muestran
    // los productos con STOCK_BAJO kilos o menos
    private void MostrarProductos()
    {
        if (chkSoloStockBajo.Checked)
            dgvStock.DataSource = productos.Where(p => p.StockKg <= STOCK_BAJO).ToList();
        else
            dgvStock.DataSource = productos;
    }

    private void chkSoloStockBajo_CheckedChanged(object sender, EventArgs e)
    {
        MostrarProductos();
    }

    // CellFormatting se ejecuta cada vez que se va a pintar una celda.
    // Si el producto de esa fila tiene stock crítico, la celda se pinta en rojo.
    private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        Producto producto = dgvStock.Rows[e.RowIndex].DataBoundItem as Producto;
        if (producto != null && producto.StockKg <= STOCK_BAJO)
        {
            e.CellStyle.BackColor = Color.LightCoral;
        }
    }
}
