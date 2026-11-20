namespace FruteriaApp;

// Pantalla principal: hace de menú y abre las demás pantallas.
public partial class FormMenu : Form
{
    // Único ApiClient de toda la aplicación. Se pasa a cada pantalla
    // por su constructor, así todas usan la misma conexión con la API.
    private readonly ApiClient api = new ApiClient();

    public FormMenu()
    {
        InitializeComponent();
    }

    // ShowDialog abre la pantalla y espera a que se cierre antes de volver al menú.
    // "using" libera la ventana de memoria cuando se cierra.
    private void btnCatalogo_Click(object sender, EventArgs e)
    {
        using FormCatalogo form = new FormCatalogo(api);
        form.ShowDialog();
    }

    private void btnStock_Click(object sender, EventArgs e)
    {
        using FormStock form = new FormStock(api);
        form.ShowDialog();
    }

    private void btnVentas_Click(object sender, EventArgs e)
    {
        using FormVentas form = new FormVentas(api);
        form.ShowDialog();
    }
}
