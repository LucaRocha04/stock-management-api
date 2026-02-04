namespace SistemaVentas.Forms
{
    partial class FormHistorialVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.btnVerDetalle = new Button();
            this.btnBuscar = new Button();
            this.btnActualizar = new Button();
            this.cmbFiltroCliente = new ComboBox();
            this.lblFiltroCliente = new Label();
            this.txtFiltroCliente = new TextBox();
            this.lblBuscarCliente = new Label();
            this.dtpHasta = new DateTimePicker();
            this.lblHasta = new Label();
            this.dtpDesde = new DateTimePicker();
            this.lblDesde = new Label();
            this.lblTitulo = new Label();
            this.dgvVentas = new DataGridView();
            this.panelEstadisticas = new Panel();
            this.panelTarjetasVentas = new Panel();
            this.lblPromedioVenta = new Label();
            this.lblMontoTotal = new Label();
            this.lblTotalVentas = new Label();
            this.lblEstadisticas = new Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.panelEstadisticas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.FromArgb(52, 73, 94);
            this.panelTop.Controls.Add(this.btnVerDetalle);
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.btnActualizar);
            this.panelTop.Controls.Add(this.cmbFiltroCliente);
            this.panelTop.Controls.Add(this.lblFiltroCliente);
            this.panelTop.Controls.Add(this.txtFiltroCliente);
            this.panelTop.Controls.Add(this.lblBuscarCliente);
            this.panelTop.Controls.Add(this.dtpHasta);
            this.panelTop.Controls.Add(this.lblHasta);
            this.panelTop.Controls.Add(this.dtpDesde);
            this.panelTop.Controls.Add(this.lblDesde);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(1400, 100);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(270, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊 Historial de Ventas";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDesde.ForeColor = Color.White;
            this.lblDesde.Location = new Point(20, 50);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new Size(42, 15);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = DateTimePickerFormat.Short;
            this.dtpDesde.Location = new Point(70, 47);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new Size(100, 23);
            this.dtpDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblHasta.ForeColor = Color.White;
            this.lblHasta.Location = new Point(190, 50);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new Size(38, 15);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = DateTimePickerFormat.Short;
            this.dtpHasta.Location = new Point(240, 47);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new Size(100, 23);
            this.dtpHasta.TabIndex = 4;
            // 
            // lblBuscarCliente
            // 
            this.lblBuscarCliente.AutoSize = true;
            this.lblBuscarCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblBuscarCliente.ForeColor = Color.White;
            this.lblBuscarCliente.Location = new Point(360, 50);
            this.lblBuscarCliente.Name = "lblBuscarCliente";
            this.lblBuscarCliente.Size = new Size(48, 15);
            this.lblBuscarCliente.TabIndex = 5;
            this.lblBuscarCliente.Text = "Cliente:";
            // 
            // txtFiltroCliente
            // 
            this.txtFiltroCliente.Location = new Point(420, 47);
            this.txtFiltroCliente.Name = "txtFiltroCliente";
            this.txtFiltroCliente.PlaceholderText = "Buscar cliente...";
            this.txtFiltroCliente.Size = new Size(150, 23);
            this.txtFiltroCliente.TabIndex = 6;
            this.txtFiltroCliente.TextChanged += this.txtFiltroCliente_TextChanged;
            // 
            // lblFiltroCliente
            // 
            this.lblFiltroCliente.AutoSize = true;
            this.lblFiltroCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblFiltroCliente.ForeColor = Color.White;
            this.lblFiltroCliente.Location = new Point(590, 50);
            this.lblFiltroCliente.Name = "lblFiltroCliente";
            this.lblFiltroCliente.Size = new Size(58, 15);
            this.lblFiltroCliente.TabIndex = 7;
            this.lblFiltroCliente.Text = "Clientes:";
            // 
            // cmbFiltroCliente
            // 
            this.cmbFiltroCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFiltroCliente.FormattingEnabled = true;
            this.cmbFiltroCliente.Location = new Point(650, 47);
            this.cmbFiltroCliente.Name = "cmbFiltroCliente";
            this.cmbFiltroCliente.Size = new Size(150, 23);
            this.cmbFiltroCliente.TabIndex = 8;
            this.cmbFiltroCliente.SelectedIndexChanged += this.cmbFiltroCliente_SelectedIndexChanged;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = Color.FromArgb(46, 204, 113);
            this.btnBuscar.FlatStyle = FlatStyle.Flat;
            this.btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnBuscar.ForeColor = Color.White;
            this.btnBuscar.Location = new Point(820, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new Size(80, 27);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += this.btnBuscar_Click;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = Color.FromArgb(230, 126, 34);
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnActualizar.ForeColor = Color.White;
            this.btnActualizar.Location = new Point(1010, 45);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(90, 27);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Text = "🔄 Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += this.btnActualizar_Click;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = Color.FromArgb(52, 152, 219);
            this.btnVerDetalle.Enabled = false;
            this.btnVerDetalle.FlatStyle = FlatStyle.Flat;
            this.btnVerDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnVerDetalle.ForeColor = Color.White;
            this.btnVerDetalle.Location = new Point(920, 45);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new Size(80, 27);
            this.btnVerDetalle.TabIndex = 10;
            this.btnVerDetalle.Text = "Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += this.btnVerDetalle_Click;
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = Color.White;
            this.dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new Point(0, 220);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new Size(1150, 380);
            this.dgvVentas.TabIndex = 1;
            this.dgvVentas.SelectionChanged += this.dgvVentas_SelectionChanged;
            // 
            // panelTarjetasVentas
            // 
            this.panelTarjetasVentas.BackColor = Color.FromArgb(250, 250, 250);
            this.panelTarjetasVentas.Dock = DockStyle.Top;
            this.panelTarjetasVentas.Location = new Point(0, 100);
            this.panelTarjetasVentas.Name = "panelTarjetasVentas";
            this.panelTarjetasVentas.Size = new Size(1400, 120);
            this.panelTarjetasVentas.TabIndex = 3;
            // 
            // panelEstadisticas
            // 
            this.panelEstadisticas.BackColor = Color.FromArgb(236, 240, 241);
            this.panelEstadisticas.Controls.Add(this.lblPromedioVenta);
            this.panelEstadisticas.Controls.Add(this.lblMontoTotal);
            this.panelEstadisticas.Controls.Add(this.lblTotalVentas);
            this.panelEstadisticas.Controls.Add(this.lblEstadisticas);
            this.panelEstadisticas.Location = new Point(1150, 220);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Size = new Size(250, 380);
            this.panelEstadisticas.TabIndex = 2;
            // 
            // lblEstadisticas
            // 
            this.lblEstadisticas.AutoSize = true;
            this.lblEstadisticas.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblEstadisticas.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblEstadisticas.Location = new Point(20, 15);
            this.lblEstadisticas.Name = "lblEstadisticas";
            this.lblEstadisticas.Size = new Size(140, 25);
            this.lblEstadisticas.TabIndex = 0;
            this.lblEstadisticas.Text = "📊 Estadísticas";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalVentas.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblTotalVentas.Location = new Point(20, 55);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new Size(130, 20);
            this.lblTotalVentas.TabIndex = 1;
            this.lblTotalVentas.Text = "🎫 Total Ventas: 0";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMontoTotal.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblMontoTotal.Location = new Point(20, 90);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new Size(125, 19);
            this.lblMontoTotal.TabIndex = 2;
            this.lblMontoTotal.Text = "Monto Total: $0.00";
            // 
            // lblPromedioVenta
            // 
            this.lblPromedioVenta.AutoSize = true;
            this.lblPromedioVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPromedioVenta.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblPromedioVenta.Location = new Point(20, 120);
            this.lblPromedioVenta.Name = "lblPromedioVenta";
            this.lblPromedioVenta.Size = new Size(154, 19);
            this.lblPromedioVenta.TabIndex = 3;
            this.lblPromedioVenta.Text = "Promedio Venta: $0.00";
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 600);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.panelTarjetasVentas);
            this.Controls.Add(this.panelEstadisticas);
            this.Controls.Add(this.panelTop);
            this.Name = "FormHistorialVentas";
            this.Text = "Historial de Ventas";
            this.Load += this.FormHistorialVentas_Load;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.panelEstadisticas.ResumeLayout(false);
            this.panelEstadisticas.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Label lblBuscarCliente;
        private TextBox txtFiltroCliente;
        private Label lblFiltroCliente;
        private ComboBox cmbFiltroCliente;
        private Button btnBuscar;
        private Button btnVerDetalle;
        private Button btnActualizar;
        private DataGridView dgvVentas;
        private Panel panelEstadisticas;
        private Panel panelTarjetasVentas;
        private Label lblEstadisticas;
        private Label lblTotalVentas;
        private Label lblMontoTotal;
        private Label lblPromedioVenta;
    }
}