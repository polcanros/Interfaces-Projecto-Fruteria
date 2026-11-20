namespace FruteriaApp;

// Pantalla del catálogo: muestra los productos y permite crearlos,
// editarlos y borrarlos (CRUD), además de buscarlos y filtrarlos por categoría.
public partial class FormCatalogo : Form
{
    private readonly ApiClient api;

    // Todos los productos tal como llegan de la API (sin filtrar)
    private List<Producto> productos = new List<Producto>();

    // Producto de la fila seleccionada en la tabla (null si no hay ninguna)
    private Producto productoSeleccionado = null;

    public FormCatalogo(ApiClient api)
    {
        InitializeComponent();
        this.api = api;
    }

    // Al abrir la pantalla se cargan los productos.
    // Los eventos con "await" dentro llevan "async".
    private async void FormCatalogo_Load(object sender, EventArgs e)
    {
        await CargarProductos();
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        await CargarProductos();
    }

    // Pide los productos a la API, rellena el ComboBox de categorías y muestra la tabla
    private async Task CargarProductos()
    {
        try
        {
            productos = await api.ObtenerProductosAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido conectar con la API.\n" + ex.Message, "Error");
            return;
        }

        // Se rellena el ComboBox con "Todas" + cada categoría (Distinct() quita las repetidas)
        cmbCategoria.Items.Clear();
        cmbCategoria.Items.Add("Todas");
        foreach (string categoria in productos.Select(p => p.Categoria).Distinct())
        {
            cmbCategoria.Items.Add(categoria);
        }
        cmbCategoria.SelectedItem = "Todas"; // Esto dispara SelectedIndexChanged, que muestra la tabla
    }

    // Muestra en la tabla solo los productos que cumplen la búsqueda y la categoría
    private void MostrarProductos()
    {
        string texto = txtBuscar.Text.Trim().ToLower();
        string categoria = cmbCategoria.SelectedItem as string ?? "Todas";

        List<Producto> filtrados = new List<Producto>();
        foreach (Producto p in productos)
        {
            bool cumpleTexto = p.Nombre.ToLower().Contains(texto);
            bool cumpleCategoria = categoria == "Todas" || p.Categoria == categoria;
            if (cumpleTexto && cumpleCategoria)
            {
                filtrados.Add(p);
            }
        }

        // DataSource hace que el DataGridView cree una columna por cada propiedad de Producto
        dgvProductos.DataSource = filtrados;
    }

    // Cada vez que se escribe en el buscador o se cambia la categoría se vuelve a filtrar
    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        MostrarProductos();
    }

    private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        MostrarProductos();
    }

    // Al seleccionar una fila se guarda el producto y se copian sus datos a los campos de la derecha.
    // DataBoundItem es el objeto Producto de esa fila.
    private void dgvProductos_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvProductos.CurrentRow == null)
        {
            productoSeleccionado = null;
            return;
        }

        productoSeleccionado = dgvProductos.CurrentRow.DataBoundItem as Producto;
        txtNombre.Text = productoSeleccionado.Nombre;
        txtCategoria.Text = productoSeleccionado.Categoria;
        // NumericUpDown trabaja con decimal, por eso se convierte
        nudPrecio.Value = (decimal)productoSeleccionado.PrecioKg;
        nudStock.Value = (decimal)productoSeleccionado.StockKg;
    }

    // Crea un Producto con lo que hay escrito en los campos de la derecha.
    // Devuelve null si falta el nombre o la categoría.
    private Producto LeerCampos()
    {
        if (txtNombre.Text.Trim() == "" || txtCategoria.Text.Trim() == "")
        {
            MessageBox.Show("El nombre y la categoría son obligatorios.");
            return null;
        }

        return new Producto
        {
            Nombre = txtNombre.Text.Trim(),
            Categoria = txtCategoria.Text.Trim(),
            PrecioKg = (double)nudPrecio.Value,
            StockKg = (double)nudStock.Value
        };
    }

    // Nuevo: crea un producto con los datos escritos en los campos
    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        Producto producto = LeerCampos();
        if (producto == null)
            return;

        try
        {
            await api.CrearProductoAsync(producto);
            await CargarProductos();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido crear el producto.\n" + ex.Message, "Error");
        }
    }

    // Editar: cambia el producto seleccionado por los datos escritos en los campos
    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (productoSeleccionado == null)
        {
            MessageBox.Show("Selecciona un producto de la tabla.");
            return;
        }

        Producto producto = LeerCampos();
        if (producto == null)
            return;

        try
        {
            await api.ActualizarProductoAsync(productoSeleccionado.Id, producto);
            await CargarProductos();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido editar el producto.\n" + ex.Message, "Error");
        }
    }

    // Eliminar: borra el producto seleccionado
    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (productoSeleccionado == null)
        {
            MessageBox.Show("Selecciona un producto de la tabla.");
            return;
        }

        try
        {
            await api.EliminarProductoAsync(productoSeleccionado.Id);
            await CargarProductos();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido eliminar el producto.\n" + ex.Message, "Error");
        }
    }
}
