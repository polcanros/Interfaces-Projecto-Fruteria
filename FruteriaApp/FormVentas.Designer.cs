namespace FruteriaApp;

partial class FormVentas
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
        lblProducto = new Label();
        cmbProductos = new ComboBox();
        lblKilos = new Label();
        nudKilos = new NumericUpDown();
        btnAnadir = new Button();
        dgvCarrito = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colProducto = new DataGridViewTextBoxColumn();
        colKilos = new DataGridViewTextBoxColumn();
        colPrecio = new DataGridViewTextBoxColumn();
        colSubtotal = new DataGridViewTextBoxColumn();
        lblTotal = new Label();
        btnConfirmar = new Button();
        ((System.ComponentModel.ISupportInitialize)nudKilos).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
        SuspendLayout();
        //
        // lblProducto
        //
        lblProducto.AutoSize = true;
        lblProducto.Location = new Point(12, 15);
        lblProducto.Name = "lblProducto";
        lblProducto.Text = "Producto:";
        //
        // cmbProductos
        //
        cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProductos.Location = new Point(80, 12);
        cmbProductos.Name = "cmbProductos";
        cmbProductos.Size = new Size(180, 23);
        //
        // lblKilos
        //
        lblKilos.AutoSize = true;
        lblKilos.Location = new Point(280, 15);
        lblKilos.Name = "lblKilos";
        lblKilos.Text = "Kilos:";
        //
        // nudKilos
        //
        nudKilos.DecimalPlaces = 2;
        nudKilos.Increment = 0.5M;
        nudKilos.Location = new Point(320, 12);
        nudKilos.Maximum = 1000M;
        nudKilos.Name = "nudKilos";
        nudKilos.Size = new Size(80, 23);
        nudKilos.Value = 1M;
        //
        // btnAnadir
        //
        btnAnadir.Location = new Point(420, 8);
        btnAnadir.Name = "btnAnadir";
        btnAnadir.Size = new Size(130, 30);
        btnAnadir.Text = "Añadir al carrito";
        btnAnadir.Click += btnAnadir_Click;
        //
        // colId
        //
        colId.HeaderText = "Id";
        colId.Name = "colId";
        colId.Visible = false;
        //
        // colProducto
        //
        colProducto.HeaderText = "Producto";
        colProducto.Name = "colProducto";
        colProducto.ReadOnly = true;
        //
        // colKilos
        //
        colKilos.HeaderText = "Kilos (editable)";
        colKilos.Name = "colKilos";
        //
        // colPrecio
        //
        colPrecio.HeaderText = "Precio / kg";
        colPrecio.Name = "colPrecio";
        colPrecio.ReadOnly = true;
        //
        // colSubtotal
        //
        colSubtotal.HeaderText = "Subtotal";
        colSubtotal.Name = "colSubtotal";
        colSubtotal.ReadOnly = true;
        //
        // dgvCarrito
        //
        dgvCarrito.AllowUserToAddRows = false;
        dgvCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCarrito.Columns.AddRange(new DataGridViewColumn[] { colId, colProducto, colKilos, colPrecio, colSubtotal });
        dgvCarrito.Location = new Point(12, 50);
        dgvCarrito.Name = "dgvCarrito";
        dgvCarrito.RowHeadersVisible = false;
        dgvCarrito.Size = new Size(560, 280);
        dgvCarrito.CellValueChanged += dgvCarrito_CellValueChanged;
        //
        // lblTotal
        //
        lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotal.Location = new Point(12, 345);
        lblTotal.Name = "lblTotal";
        lblTotal.Text = "Total: 0,00 €";
        //
        // btnConfirmar
        //
        btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnConfirmar.Location = new Point(442, 340);
        btnConfirmar.Name = "btnConfirmar";
        btnConfirmar.Size = new Size(130, 35);
        btnConfirmar.Text = "Confirmar venta";
        btnConfirmar.Click += btnConfirmar_Click;
        //
        // FormVentas
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(584, 387);
        Controls.Add(lblProducto);
        Controls.Add(cmbProductos);
        Controls.Add(lblKilos);
        Controls.Add(nudKilos);
        Controls.Add(btnAnadir);
        Controls.Add(dgvCarrito);
        Controls.Add(lblTotal);
        Controls.Add(btnConfirmar);
        Name = "FormVentas";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Registro de ventas";
        Load += FormVentas_Load;
        ((System.ComponentModel.ISupportInitialize)nudKilos).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblProducto;
    private ComboBox cmbProductos;
    private Label lblKilos;
    private NumericUpDown nudKilos;
    private Button btnAnadir;
    private DataGridView dgvCarrito;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colProducto;
    private DataGridViewTextBoxColumn colKilos;
    private DataGridViewTextBoxColumn colPrecio;
    private DataGridViewTextBoxColumn colSubtotal;
    private Label lblTotal;
    private Button btnConfirmar;
}
