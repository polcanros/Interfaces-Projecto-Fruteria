namespace FruteriaApp;

partial class FormCatalogo
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        lblCategoria = new Label();
        cmbCategoria = new ComboBox();
        btnRefrescar = new Button();
        btnNuevo = new Button();
        btnEditar = new Button();
        btnEliminar = new Button();
        dgvProductos = new DataGridView();
        grpDatos = new GroupBox();
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblCategoriaProducto = new Label();
        txtCategoria = new TextBox();
        lblPrecio = new Label();
        nudPrecio = new NumericUpDown();
        lblStock = new Label();
        nudStock = new NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
        grpDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
        SuspendLayout();
        //
        // lblBuscar
        //
        lblBuscar.AutoSize = true;
        lblBuscar.Location = new Point(12, 15);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Text = "Buscar:";
        //
        // txtBuscar
        //
        txtBuscar.Location = new Point(70, 12);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new Size(200, 23);
        txtBuscar.TextChanged += txtBuscar_TextChanged;
        //
        // lblCategoria
        //
        lblCategoria.AutoSize = true;
        lblCategoria.Location = new Point(290, 15);
        lblCategoria.Name = "lblCategoria";
        lblCategoria.Text = "Categoría:";
        //
        // cmbCategoria
        //
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategoria.Location = new Point(365, 12);
        cmbCategoria.Name = "cmbCategoria";
        cmbCategoria.Size = new Size(150, 23);
        cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
        //
        // btnRefrescar
        //
        btnRefrescar.Location = new Point(12, 45);
        btnRefrescar.Name = "btnRefrescar";
        btnRefrescar.Size = new Size(100, 30);
        btnRefrescar.Text = "Refrescar";
        btnRefrescar.Click += btnRefrescar_Click;
        //
        // btnNuevo
        //
        btnNuevo.Location = new Point(118, 45);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(100, 30);
        btnNuevo.Text = "Nuevo";
        btnNuevo.Click += btnNuevo_Click;
        //
        // btnEditar
        //
        btnEditar.Location = new Point(224, 45);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(100, 30);
        btnEditar.Text = "Editar";
        btnEditar.Click += btnEditar_Click;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(330, 45);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(100, 30);
        btnEliminar.Text = "Eliminar";
        btnEliminar.Click += btnEliminar_Click;
        //
        // dgvProductos
        //
        dgvProductos.AllowUserToAddRows = false;
        dgvProductos.AllowUserToDeleteRows = false;
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProductos.Location = new Point(12, 85);
        dgvProductos.MultiSelect = false;
        dgvProductos.Name = "dgvProductos";
        dgvProductos.ReadOnly = true;
        dgvProductos.RowHeadersVisible = false;
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProductos.Size = new Size(560, 360);
        dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        //
        // grpDatos
        //
        grpDatos.Controls.Add(lblNombre);
        grpDatos.Controls.Add(txtNombre);
        grpDatos.Controls.Add(lblCategoriaProducto);
        grpDatos.Controls.Add(txtCategoria);
        grpDatos.Controls.Add(lblPrecio);
        grpDatos.Controls.Add(nudPrecio);
        grpDatos.Controls.Add(lblStock);
        grpDatos.Controls.Add(nudStock);
        grpDatos.Location = new Point(585, 85);
        grpDatos.Name = "grpDatos";
        grpDatos.Size = new Size(260, 160);
        grpDatos.Text = "Datos del producto";
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(10, 28);
        lblNombre.Name = "lblNombre";
        lblNombre.Text = "Nombre:";
        //
        // txtNombre
        //
        txtNombre.Location = new Point(110, 25);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(140, 23);
        //
        // lblCategoriaProducto
        //
        lblCategoriaProducto.AutoSize = true;
        lblCategoriaProducto.Location = new Point(10, 61);
        lblCategoriaProducto.Name = "lblCategoriaProducto";
        lblCategoriaProducto.Text = "Categoría:";
        //
        // txtCategoria
        //
        txtCategoria.Location = new Point(110, 58);
        txtCategoria.Name = "txtCategoria";
        txtCategoria.Size = new Size(140, 23);
        //
        // lblPrecio
        //
        lblPrecio.AutoSize = true;
        lblPrecio.Location = new Point(10, 94);
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Text = "Precio / kg (€):";
        //
        // nudPrecio
        //
        nudPrecio.DecimalPlaces = 2;
        nudPrecio.Increment = 0.1M;
        nudPrecio.Location = new Point(110, 91);
        nudPrecio.Maximum = 1000M;
        nudPrecio.Name = "nudPrecio";
        nudPrecio.Size = new Size(100, 23);
        //
        // lblStock
        //
        lblStock.AutoSize = true;
        lblStock.Location = new Point(10, 127);
        lblStock.Name = "lblStock";
        lblStock.Text = "Stock (kg):";
        //
        // nudStock
        //
        nudStock.DecimalPlaces = 2;
        nudStock.Location = new Point(110, 124);
        nudStock.Maximum = 10000M;
        nudStock.Name = "nudStock";
        nudStock.Size = new Size(100, 23);
        //
        // FormCatalogo
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(860, 457);
        Controls.Add(lblBuscar);
        Controls.Add(txtBuscar);
        Controls.Add(lblCategoria);
        Controls.Add(cmbCategoria);
        Controls.Add(btnRefrescar);
        Controls.Add(btnNuevo);
        Controls.Add(btnEditar);
        Controls.Add(btnEliminar);
        Controls.Add(dgvProductos);
        Controls.Add(grpDatos);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FormCatalogo";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Catálogo de productos";
        Load += FormCatalogo_Load;
        ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
        grpDatos.ResumeLayout(false);
        grpDatos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblBuscar;
    private TextBox txtBuscar;
    private Label lblCategoria;
    private ComboBox cmbCategoria;
    private Button btnRefrescar;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
    private DataGridView dgvProductos;
    private GroupBox grpDatos;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblCategoriaProducto;
    private TextBox txtCategoria;
    private Label lblPrecio;
    private NumericUpDown nudPrecio;
    private Label lblStock;
    private NumericUpDown nudStock;
}
