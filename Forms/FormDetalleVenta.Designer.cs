namespace SistemaVentas.Forms
{
    partial class FormDetalleVenta
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
            this.lblNumeroVenta = new Label();
            this.panelInfo = new Panel();
            this.lblObservaciones = new Label();
            this.lblFormaPago = new Label();
            this.lblDocumento = new Label();
            this.lblCliente = new Label();
            this.lblFecha = new Label();
            this.dgvDetalles = new DataGridView();
            this.panelBottom = new Panel();
            this.btnImprimir = new Button();
            this.btnCerrar = new Button();
            this.lblTotal = new Label();
            this.lblImpuesto = new Label();
            this.lblSubtotal = new Label();
            this.panelTop.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.FromArgb(52, 73, 94);
            this.panelTop.Controls.Add(this.lblNumeroVenta);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(800, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.AutoSize = true;
            this.lblNumeroVenta.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblNumeroVenta.ForeColor = Color.White;
            this.lblNumeroVenta.Location = new Point(20, 10);
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new Size(154, 30);
            this.lblNumeroVenta.TabIndex = 0;
            this.lblNumeroVenta.Text = "Detalle de Venta";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = Color.FromArgb(236, 240, 241);
            this.panelInfo.Controls.Add(this.lblObservaciones);
            this.panelInfo.Controls.Add(this.lblFormaPago);
            this.panelInfo.Controls.Add(this.lblDocumento);
            this.panelInfo.Controls.Add(this.lblCliente);
            this.panelInfo.Controls.Add(this.lblFecha);
            this.panelInfo.Dock = DockStyle.Top;
            this.panelInfo.Location = new Point(0, 50);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new Size(800, 120);
            this.panelInfo.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFecha.Location = new Point(20, 15);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new Size(49, 19);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCliente.Location = new Point(20, 40);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(58, 19);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDocumento.Location = new Point(20, 65);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new Size(89, 19);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "Documento:";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFormaPago.Location = new Point(400, 15);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new Size(105, 19);
            this.lblFormaPago.TabIndex = 3;
            this.lblFormaPago.Text = "Forma de Pago:";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblObservaciones.Location = new Point(400, 40);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new Size(109, 19);
            this.lblObservaciones.TabIndex = 4;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.BackgroundColor = Color.White;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Dock = DockStyle.Fill;
            this.dgvDetalles.Location = new Point(0, 170);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.Size = new Size(800, 230);
            this.dgvDetalles.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = Color.FromArgb(52, 73, 94);
            this.panelBottom.Controls.Add(this.btnImprimir);
            this.panelBottom.Controls.Add(this.btnCerrar);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Controls.Add(this.lblImpuesto);
            this.panelBottom.Controls.Add(this.lblSubtotal);
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Location = new Point(0, 400);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new Size(800, 100);
            this.panelBottom.TabIndex = 3;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblSubtotal.ForeColor = Color.White;
            this.lblSubtotal.Location = new Point(20, 15);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new Size(79, 21);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoSize = true;
            this.lblImpuesto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblImpuesto.ForeColor = Color.White;
            this.lblImpuesto.Location = new Point(20, 40);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new Size(83, 21);
            this.lblImpuesto.TabIndex = 1;
            this.lblImpuesto.Text = "Impuesto:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblTotal.Location = new Point(20, 65);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(85, 30);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "TOTAL:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = Color.FromArgb(149, 165, 166);
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Location = new Point(670, 50);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(100, 35);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += this.btnCerrar_Click;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = Color.FromArgb(52, 152, 219);
            this.btnImprimir.FlatStyle = FlatStyle.Flat;
            this.btnImprimir.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnImprimir.ForeColor = Color.White;
            this.btnImprimir.Location = new Point(560, 50);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new Size(100, 35);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += this.btnImprimir_Click;
            // 
            // FormDetalleVenta
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 500);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalleVenta";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Detalle de Venta";
            this.Load += this.FormDetalleVenta_Load;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblNumeroVenta;
        private Panel panelInfo;
        private Label lblFecha;
        private Label lblCliente;
        private Label lblDocumento;
        private Label lblFormaPago;
        private Label lblObservaciones;
        private DataGridView dgvDetalles;
        private Panel panelBottom;
        private Label lblSubtotal;
        private Label lblImpuesto;
        private Label lblTotal;
        private Button btnCerrar;
        private Button btnImprimir;
    }
}