namespace SistemaVentas.Forms
{
    partial class FormGraficos
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
            this.panelHeader = new Panel();
            this.lblTitulo = new Label();
            this.panelBotones = new Panel();
            this.btnActualizar = new Button();
            this.btnVentas = new Button();
            this.btnProductos = new Button();
            this.panelTarjetas = new Panel();
            this.panelEstadisticas = new Panel();
            this.lblEstadisticas = new Label();
            this.panelHeader.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelEstadisticas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(52, 73, 94);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new Padding(20);
            this.panelHeader.Size = new Size(984, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(20, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(340, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊 Reportes y Estadísticas";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = Color.FromArgb(236, 240, 241);
            this.panelBotones.Controls.Add(this.btnActualizar);
            this.panelBotones.Controls.Add(this.btnVentas);
            this.panelBotones.Controls.Add(this.btnProductos);
            this.panelBotones.Dock = DockStyle.Top;
            this.panelBotones.Location = new Point(0, 80);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new Padding(20, 15, 20, 15);
            this.panelBotones.Size = new Size(984, 70);
            this.panelBotones.TabIndex = 1;
            // 
            // panelTarjetas
            // 
            this.panelTarjetas.AutoScroll = true;
            this.panelTarjetas.BackColor = Color.FromArgb(250, 250, 250);
            this.panelTarjetas.Dock = DockStyle.Top;
            this.panelTarjetas.Location = new Point(0, 150);
            this.panelTarjetas.Name = "panelTarjetas";
            this.panelTarjetas.Padding = new Padding(20);
            this.panelTarjetas.Size = new Size(984, 200);
            this.panelTarjetas.TabIndex = 2;
            // 
            // panelEstadisticas
            // 
            this.panelEstadisticas.BackColor = Color.White;
            this.panelEstadisticas.Controls.Add(this.lblEstadisticas);
            this.panelEstadisticas.Dock = DockStyle.Fill;
            this.panelEstadisticas.Location = new Point(0, 350);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Padding = new Padding(20);
            this.panelEstadisticas.Size = new Size(984, 250);
            this.panelEstadisticas.TabIndex = 3;
            // 
            // lblEstadisticas
            // 
            this.lblEstadisticas.BackColor = Color.White;
            this.lblEstadisticas.Dock = DockStyle.Fill;
            this.lblEstadisticas.Font = new Font("Segoe UI", 10F);
            this.lblEstadisticas.Location = new Point(20, 20);
            this.lblEstadisticas.Name = "lblEstadisticas";
            this.lblEstadisticas.Size = new Size(944, 210);
            this.lblEstadisticas.TabIndex = 0;
            this.lblEstadisticas.Text = "Cargando estadísticas...";
            this.lblEstadisticas.TextAlign = ContentAlignment.TopLeft;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnActualizar.BackColor = Color.FromArgb(46, 204, 113);
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnActualizar.ForeColor = Color.White;
            this.btnActualizar.Location = new Point(820, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(130, 40);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "🔄 Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += this.btnActualizar_Click;
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = Color.FromArgb(52, 152, 219);
            this.btnVentas.FlatStyle = FlatStyle.Flat;
            this.btnVentas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnVentas.ForeColor = Color.White;
            this.btnVentas.Location = new Point(20, 15);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new Size(150, 40);
            this.btnVentas.TabIndex = 0;
            this.btnVentas.Text = "📊 VENTAS";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += this.btnVentas_Click;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = Color.FromArgb(155, 89, 182);
            this.btnProductos.FlatStyle = FlatStyle.Flat;
            this.btnProductos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnProductos.ForeColor = Color.White;
            this.btnProductos.Location = new Point(180, 15);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new Size(150, 40);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "📦 PRODUCTOS";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += this.btnProductos_Click;
            // 
            // panelTarjetas
            // 
            this.panelTarjetas.AutoScroll = true;
            this.panelTarjetas.BackColor = Color.FromArgb(250, 250, 250);
            this.panelTarjetas.Dock = DockStyle.Top;
            this.panelTarjetas.Location = new Point(0, 150);
            this.panelTarjetas.Name = "panelTarjetas";
            this.panelTarjetas.Padding = new Padding(20);
            this.panelTarjetas.Size = new Size(1000, 180);
            this.panelTarjetas.TabIndex = 2;
            // 
            // FormGraficos
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.panelEstadisticas);
            this.Controls.Add(this.panelTarjetas);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGraficos";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "📊 Reportes y Estadísticas";
            this.Load += this.FormGraficos_Load;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelEstadisticas.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelBotones;
        private Button btnActualizar;
        private Button btnVentas;
        private Button btnProductos;
        private Panel panelTarjetas;
        private Panel panelEstadisticas;
        private Label lblEstadisticas;
    }
}