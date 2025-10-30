namespace SistemaVentas.Forms
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.inicioToolStripMenuItem = new ToolStripMenuItem();
            this.productosToolStripMenuItem = new ToolStripMenuItem();
            this.gestionarProductosToolStripMenuItem = new ToolStripMenuItem();
            this.ventasToolStripMenuItem = new ToolStripMenuItem();
            this.nuevaVentaToolStripMenuItem = new ToolStripMenuItem();
            this.historialVentasToolStripMenuItem = new ToolStripMenuItem();
            this.reportesToolStripMenuItem = new ToolStripMenuItem();
            this.ventasMensualesToolStripMenuItem = new ToolStripMenuItem();
            this.productosMasVendidosToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip1 = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.lblFecha = new ToolStripStatusLabel();
            this.panelPrincipal = new Panel();
            this.lblBienvenida = new Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = Color.FromArgb(52, 73, 94);
            this.menuStrip1.ForeColor = Color.White;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new Size(1200, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.ForeColor = Color.White;
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new Size(59, 24);
            this.inicioToolStripMenuItem.Text = "🏠 Inicio";
            this.inicioToolStripMenuItem.Click += this.inicioToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.gestionarProductosToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // gestionarProductosToolStripMenuItem
            // 
            this.gestionarProductosToolStripMenuItem.Name = "gestionarProductosToolStripMenuItem";
            this.gestionarProductosToolStripMenuItem.Size = new Size(180, 22);
            this.gestionarProductosToolStripMenuItem.Text = "Gestionar Productos";
            this.gestionarProductosToolStripMenuItem.Click += this.gestionarProductosToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.nuevaVentaToolStripMenuItem,
            this.historialVentasToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new Size(53, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // nuevaVentaToolStripMenuItem
            // 
            this.nuevaVentaToolStripMenuItem.Name = "nuevaVentaToolStripMenuItem";
            this.nuevaVentaToolStripMenuItem.Size = new Size(161, 22);
            this.nuevaVentaToolStripMenuItem.Text = "Nueva Venta";
            this.nuevaVentaToolStripMenuItem.Click += this.nuevaVentaToolStripMenuItem_Click;
            // 
            // historialVentasToolStripMenuItem
            // 
            this.historialVentasToolStripMenuItem.Name = "historialVentasToolStripMenuItem";
            this.historialVentasToolStripMenuItem.Size = new Size(161, 22);
            this.historialVentasToolStripMenuItem.Text = "Historial Ventas";
            this.historialVentasToolStripMenuItem.Click += this.historialVentasToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.ventasMensualesToolStripMenuItem,
            this.productosMasVendidosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // ventasMensualesToolStripMenuItem
            // 
            this.ventasMensualesToolStripMenuItem.Name = "ventasMensualesToolStripMenuItem";
            this.ventasMensualesToolStripMenuItem.Size = new Size(197, 22);
            this.ventasMensualesToolStripMenuItem.Text = "Ventas Mensuales";
            this.ventasMensualesToolStripMenuItem.Click += this.ventasMensualesToolStripMenuItem_Click;
            // 
            // productosMasVendidosToolStripMenuItem
            // 
            this.productosMasVendidosToolStripMenuItem.Name = "productosMasVendidosToolStripMenuItem";
            this.productosMasVendidosToolStripMenuItem.Size = new Size(197, 22);
            this.productosMasVendidosToolStripMenuItem.Text = "Productos Más Vendidos";
            this.productosMasVendidosToolStripMenuItem.Click += this.productosMasVendidosToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
            this.lblStatus,
            this.lblFecha});
            this.statusStrip1.Location = new Point(0, 728);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(42, 17);
            this.lblStatus.Text = "Listo";
            // 
            // lblFecha
            // 
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new Size(1143, 17);
            this.lblFecha.Spring = true;
            this.lblFecha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.lblBienvenida);
            this.panelPrincipal.Dock = DockStyle.Fill;
            this.panelPrincipal.Location = new Point(0, 24);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new Size(1200, 704);
            this.panelPrincipal.TabIndex = 2;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblBienvenida.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblBienvenida.Location = new Point(400, 300);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new Size(400, 45);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Sistema de Ventas y Stock";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 750);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ventas y Stock";
            this.WindowState = FormWindowState.Maximized;
            this.Load += this.FormPrincipal_Load;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem gestionarProductosToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem nuevaVentaToolStripMenuItem;
        private ToolStripMenuItem historialVentasToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem ventasMensualesToolStripMenuItem;
        private ToolStripMenuItem productosMasVendidosToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblFecha;
        private Panel panelPrincipal;
        private Label lblBienvenida;
    }
}