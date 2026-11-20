namespace FruteriaApp;

partial class FormStock
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
        btnRefrescar = new Button();
        chkSoloStockBajo = new CheckBox();
        dgvStock = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
        SuspendLayout();
        //
        // btnRefrescar
        //
        btnRefrescar.Location = new Point(12, 10);
        btnRefrescar.Name = "btnRefrescar";
        btnRefrescar.Size = new Size(100, 30);
        btnRefrescar.Text = "Refrescar";
        btnRefrescar.Click += btnRefrescar_Click;
        //
        // chkSoloStockBajo
        //
        chkSoloStockBajo.AutoSize = true;
        chkSoloStockBajo.Location = new Point(130, 16);
        chkSoloStockBajo.Name = "chkSoloStockBajo";
        chkSoloStockBajo.Text = "Solo stock bajo (5 kg o menos)";
        chkSoloStockBajo.CheckedChanged += chkSoloStockBajo_CheckedChanged;
        //
        // dgvStock
        //
        dgvStock.AllowUserToAddRows = false;
        dgvStock.AllowUserToDeleteRows = false;
        dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStock.Location = new Point(12, 50);
        dgvStock.Name = "dgvStock";
        dgvStock.ReadOnly = true;
        dgvStock.RowHeadersVisible = false;
        dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStock.Size = new Size(660, 395);
        dgvStock.CellFormatting += dgvStock_CellFormatting;
        //
        // FormStock
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(684, 457);
        Controls.Add(btnRefrescar);
        Controls.Add(chkSoloStockBajo);
        Controls.Add(dgvStock);
        Name = "FormStock";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Control de stock";
        Load += FormStock_Load;
        ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnRefrescar;
    private CheckBox chkSoloStockBajo;
    private DataGridView dgvStock;
}
