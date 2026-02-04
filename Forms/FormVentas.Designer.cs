namespace SistemaVentas.Forms
{
    partial class FormVentas
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
            this.panelVenta = new Panel();
            this.lblTitulo = new Label();
            this.lblCliente = new Label();
            this.txtCliente = new TextBox();

            this.lblFecha = new Label();
            this.dtpFecha = new DateTimePicker();
            this.lblFormaPago = new Label();
            this.cmbFormaPago = new ComboBox();
            this.panelProducto = new Panel();
            this.lblProducto = new Label();
            this.cmbProducto = new ComboBox();
            this.lblCodigo = new Label();
            this.txtCodigo = new TextBox();
            this.lblCantidad = new Label();
            this.numCantidad = new NumericUpDown();
            this.lblPrecio = new Label();
            this.numPrecio = new NumericUpDown();
            this.lblDescuento = new Label();
            this.numDescuento = new NumericUpDown();
            this.lblStock = new Label();
            this.lblSubtotal = new Label();
            this.btnAgregar = new Button();
            this.btnQuitar = new Button();
            this.dgvDetalle = new DataGridView();
            this.panelTotales = new Panel();
            this.lblSubtotalVenta = new Label();
            this.lblImpuesto = new Label();
            this.lblTotalVenta = new Label();
            this.btnGuardarVenta = new Button();
            this.btnCancelar = new Button();
            this.lblObservaciones = new Label();
            this.txtObservaciones = new TextBox();
            this.panelVenta.SuspendLayout();
            this.panelProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panelTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelVenta
            // 
            this.panelVenta.BackColor = Color.FromArgb(236, 240, 241);
            this.panelVenta.Controls.Add(this.txtObservaciones);
            this.panelVenta.Controls.Add(this.lblObservaciones);
            this.panelVenta.Controls.Add(this.cmbFormaPago);
            this.panelVenta.Controls.Add(this.lblFormaPago);
            this.panelVenta.Controls.Add(this.dtpFecha);
            this.panelVenta.Controls.Add(this.lblFecha);

            this.panelVenta.Controls.Add(this.txtCliente);
            this.panelVenta.Controls.Add(this.lblCliente);
            this.panelVenta.Controls.Add(this.lblTitulo);
            this.panelVenta.Dock = DockStyle.Top;
            this.panelVenta.Location = new Point(0, 0);
            this.panelVenta.Name = "panelVenta";
            this.panelVenta.Size = new Size(1200, 150);
            this.panelVenta.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTitulo.Location = new Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(136, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Venta";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCliente.Location = new Point(20, 60);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(51, 15);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new Point(20, 80);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new Size(250, 23);
            this.txtCliente.TabIndex = 2;
            // 
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblFecha.Location = new Point(460, 60);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new Size(42, 15);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new Point(460, 80);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new Size(150, 23);
            this.dtpFecha.TabIndex = 6;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblFormaPago.Location = new Point(630, 60);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new Size(89, 15);
            this.lblFormaPago.TabIndex = 7;
            this.lblFormaPago.Text = "Forma de Pago:";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de Crédito",
            "Tarjeta de Débito",
            "Transferencia"});
            this.cmbFormaPago.Location = new Point(630, 80);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new Size(150, 23);
            this.cmbFormaPago.TabIndex = 8;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblObservaciones.Location = new Point(20, 110);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new Size(89, 15);
            this.lblObservaciones.TabIndex = 9;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new Point(120, 110);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new Size(400, 23);
            this.txtObservaciones.TabIndex = 10;
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = Color.FromArgb(189, 195, 199);
            this.panelProducto.Controls.Add(this.btnQuitar);
            this.panelProducto.Controls.Add(this.btnAgregar);
            this.panelProducto.Controls.Add(this.lblSubtotal);
            this.panelProducto.Controls.Add(this.lblStock);
            this.panelProducto.Controls.Add(this.numDescuento);
            this.panelProducto.Controls.Add(this.lblDescuento);
            this.panelProducto.Controls.Add(this.numPrecio);
            this.panelProducto.Controls.Add(this.lblPrecio);
            this.panelProducto.Controls.Add(this.numCantidad);
            this.panelProducto.Controls.Add(this.lblCantidad);
            this.panelProducto.Controls.Add(this.txtCodigo);
            this.panelProducto.Controls.Add(this.lblCodigo);
            this.panelProducto.Controls.Add(this.cmbProducto);
            this.panelProducto.Controls.Add(this.lblProducto);
            this.panelProducto.Dock = DockStyle.Top;
            this.panelProducto.Location = new Point(0, 150);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new Size(1200, 80);
            this.panelProducto.TabIndex = 1;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblProducto.Location = new Point(20, 15);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new Size(59, 15);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new Point(20, 35);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new Size(200, 23);
            this.cmbProducto.TabIndex = 1;
            this.cmbProducto.SelectedIndexChanged += this.cmbProducto_SelectedIndexChanged;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCodigo.Location = new Point(240, 15);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new Size(48, 15);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new Point(240, 35);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new Size(100, 23);
            this.txtCodigo.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCantidad.Location = new Point(360, 15);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new Size(59, 15);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new Point(360, 35);
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new Size(80, 23);
            this.numCantidad.TabIndex = 5;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.ValueChanged += this.numCantidad_ValueChanged;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPrecio.Location = new Point(460, 15);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new Size(44, 15);
            this.lblPrecio.TabIndex = 6;
            this.lblPrecio.Text = "Precio:";
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new Point(460, 35);
            this.numPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new Size(100, 23);
            this.numPrecio.TabIndex = 7;
            this.numPrecio.ValueChanged += this.numPrecio_ValueChanged;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDescuento.Location = new Point(580, 15);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new Size(73, 15);
            this.lblDescuento.TabIndex = 8;
            this.lblDescuento.Text = "Descuento%:";
            // 
            // numDescuento
            // 
            this.numDescuento.DecimalPlaces = 2;
            this.numDescuento.Location = new Point(580, 35);
            this.numDescuento.Name = "numDescuento";
            this.numDescuento.Size = new Size(80, 23);
            this.numDescuento.TabIndex = 9;
            this.numDescuento.ValueChanged += this.numDescuento_ValueChanged;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblStock.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblStock.Location = new Point(680, 15);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new Size(50, 15);
            this.lblStock.TabIndex = 10;
            this.lblStock.Text = "Stock: 0";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSubtotal.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblSubtotal.Location = new Point(680, 40);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new Size(82, 15);
            this.lblSubtotal.TabIndex = 11;
            this.lblSubtotal.Text = "Subtotal: $0.00";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAgregar.FlatStyle = FlatStyle.Flat;
            this.btnAgregar.ForeColor = Color.White;
            this.btnAgregar.Location = new Point(800, 25);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(80, 30);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += this.btnAgregar_Click;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = Color.FromArgb(231, 76, 60);
            this.btnQuitar.FlatStyle = FlatStyle.Flat;
            this.btnQuitar.ForeColor = Color.White;
            this.btnQuitar.Location = new Point(890, 25);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new Size(80, 30);
            this.btnQuitar.TabIndex = 13;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += this.btnQuitar_Click;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.BackgroundColor = Color.White;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = DockStyle.Fill;
            this.dgvDetalle.Location = new Point(0, 230);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.Size = new Size(1000, 370);
            this.dgvDetalle.TabIndex = 2;
            // 
            // panelTotales
            // 
            this.panelTotales.BackColor = Color.FromArgb(52, 73, 94);
            this.panelTotales.Controls.Add(this.btnCancelar);
            this.panelTotales.Controls.Add(this.btnGuardarVenta);
            this.panelTotales.Controls.Add(this.lblTotalVenta);
            this.panelTotales.Controls.Add(this.lblImpuesto);
            this.panelTotales.Controls.Add(this.lblSubtotalVenta);
            this.panelTotales.Dock = DockStyle.Right;
            this.panelTotales.Location = new Point(1100, 230);
            this.panelTotales.Name = "panelTotales";
            this.panelTotales.Size = new Size(300, 370);
            this.panelTotales.TabIndex = 3;
            // 
            // lblSubtotalVenta
            // 
            this.lblSubtotalVenta.AutoSize = false;
            this.lblSubtotalVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSubtotalVenta.ForeColor = Color.White;
            this.lblSubtotalVenta.Location = new Point(20, 30);
            this.lblSubtotalVenta.Name = "lblSubtotalVenta";
            this.lblSubtotalVenta.Size = new Size(260, 19);
            this.lblSubtotalVenta.TabIndex = 0;
            this.lblSubtotalVenta.Text = "Subtotal: $0";
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoSize = false;
            this.lblImpuesto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblImpuesto.ForeColor = Color.White;
            this.lblImpuesto.Location = new Point(20, 60);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new Size(260, 19);
            this.lblImpuesto.TabIndex = 1;
            this.lblImpuesto.Text = "Impuesto (18%): $0";
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = false;
            this.lblTotalVenta.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotalVenta.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblTotalVenta.Location = new Point(20, 100);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new Size(260, 25);
            this.lblTotalVenta.TabIndex = 2;
            this.lblTotalVenta.Text = "TOTAL: $0";
            // 
            // btnGuardarVenta
            // 
            this.btnGuardarVenta.BackColor = Color.FromArgb(46, 204, 113);
            this.btnGuardarVenta.FlatStyle = FlatStyle.Flat;
            this.btnGuardarVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnGuardarVenta.ForeColor = Color.White;
            this.btnGuardarVenta.Location = new Point(20, 160);
            this.btnGuardarVenta.Name = "btnGuardarVenta";
            this.btnGuardarVenta.Size = new Size(260, 40);
            this.btnGuardarVenta.TabIndex = 3;
            this.btnGuardarVenta.Text = "GUARDAR VENTA";
            this.btnGuardarVenta.UseVisualStyleBackColor = false;
            this.btnGuardarVenta.Click += this.btnGuardarVenta_Click;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(20, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(160, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += this.btnCancelar_Click;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 600);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.panelTotales);
            this.Controls.Add(this.panelProducto);
            this.Controls.Add(this.panelVenta);
            this.Name = "FormVentas";
            this.Text = "Nueva Venta";
            this.panelVenta.ResumeLayout(false);
            this.panelVenta.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panelTotales.ResumeLayout(false);
            this.panelTotales.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelVenta;
        private Label lblTitulo;
        private Label lblCliente;
        private TextBox txtCliente;

        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblFormaPago;
        private ComboBox cmbFormaPago;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Panel panelProducto;
        private Label lblProducto;
        private ComboBox cmbProducto;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private Label lblDescuento;
        private NumericUpDown numDescuento;
        private Label lblStock;
        private Label lblSubtotal;
        private Button btnAgregar;
        private Button btnQuitar;
        private DataGridView dgvDetalle;
        private Panel panelTotales;
        private Label lblSubtotalVenta;
        private Label lblImpuesto;
        private Label lblTotalVenta;
        private Button btnGuardarVenta;
        private Button btnCancelar;
    }
}