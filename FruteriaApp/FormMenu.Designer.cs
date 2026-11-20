namespace FruteriaApp;

partial class FormMenu
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
        btnCatalogo = new Button();
        btnStock = new Button();
        btnVentas = new Button();
        SuspendLayout();
        //
        // btnCatalogo
        //
        btnCatalogo.Location = new Point(40, 20);
        btnCatalogo.Name = "btnCatalogo";
        btnCatalogo.Size = new Size(200, 40);
        btnCatalogo.Text = "Catálogo de productos";
        btnCatalogo.Click += btnCatalogo_Click;
        //
        // btnStock
        //
        btnStock.Location = new Point(40, 70);
        btnStock.Name = "btnStock";
        btnStock.Size = new Size(200, 40);
        btnStock.Text = "Control de stock";
        btnStock.Click += btnStock_Click;
        //
        // btnVentas
        //
        btnVentas.Location = new Point(40, 120);
        btnVentas.Name = "btnVentas";
        btnVentas.Size = new Size(200, 40);
        btnVentas.Text = "Registro de ventas";
        btnVentas.Click += btnVentas_Click;
        //
        // FormMenu
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(280, 180);
        Controls.Add(btnCatalogo);
        Controls.Add(btnStock);
        Controls.Add(btnVentas);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FormMenu";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Frutería - Menú";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnCatalogo;
    private Button btnStock;
    private Button btnVentas;
}
