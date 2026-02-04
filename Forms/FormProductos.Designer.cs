namespace SistemaVentas.Forms
{
    partial class FormProductos
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
            this.btnVolver = new Button();
            this.btnEliminar = new Button();
            this.btnModificar = new Button();
            this.btnNuevo = new Button();
            this.txtBuscar = new TextBox();
            this.lblBuscar = new Label();
            this.cmbOrdenamiento = new ComboBox();
            this.lblOrdenamiento = new Label();
            this.panelTarjetasCategorias = new Panel();
            this.dgvProductos = new DataGridView();
            this.panelFormulario = new Panel();
            this.btnCancelar = new Button();
            this.btnGuardar = new Button();
            this.cmbCategoria = new ComboBox();
            this.numStock = new NumericUpDown();
            this.numPrecio = new NumericUpDown();
            this.txtDescripcion = new TextBox();
            this.txtNombre = new TextBox();
            this.txtCodigo = new TextBox();
            this.rbCodigoAutomatico = new RadioButton();
            this.rbCodigoManual = new RadioButton();
            this.pnlCodigoOpciones = new Panel();
            this.lblCategoria = new Label();
            this.lblStock = new Label();
            this.lblPrecio = new Label();
            this.lblDescripcion = new Label();
            this.lblNombre = new Label();
            this.lblCodigo = new Label();
            this.lblTitulo = new Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panelFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnVolver);
            this.panelTop.Controls.Add(this.btnEliminar);
            this.panelTop.Controls.Add(this.btnModificar);
            this.panelTop.Controls.Add(this.btnNuevo);
            this.panelTop.Controls.Add(this.cmbOrdenamiento);
            this.panelTop.Controls.Add(this.lblOrdenamiento);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.lblBuscar);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(1000, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
            this.btnEliminar.FlatStyle = FlatStyle.Flat;
            this.btnEliminar.ForeColor = Color.White;
            this.btnEliminar.Location = new Point(900, 20);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(80, 30);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += this.btnEliminar_Click;
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = Color.FromArgb(52, 152, 219);
            this.btnModificar.FlatStyle = FlatStyle.Flat;
            this.btnModificar.ForeColor = Color.White;
            this.btnModificar.Location = new Point(810, 20);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(80, 30);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += this.btnModificar_Click;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = Color.FromArgb(46, 204, 113);
            this.btnNuevo.FlatStyle = FlatStyle.Flat;
            this.btnNuevo.ForeColor = Color.White;
            this.btnNuevo.Location = new Point(720, 20);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(80, 30);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += this.btnNuevo_Click;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = Color.FromArgb(52, 152, 219);
            this.btnVolver.FlatStyle = FlatStyle.Flat;
            this.btnVolver.ForeColor = Color.White;
            this.btnVolver.Location = new Point(810, 20);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new Size(80, 30);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Visible = false;
            this.btnVolver.Click += this.btnVolver_Click;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new Point(80, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar por código o nombre...";
            this.txtBuscar.Size = new Size(300, 23);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += this.txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblBuscar.Location = new Point(20, 28);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new Size(47, 15);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar:";
            // 
            // cmbOrdenamiento
            // 
            this.cmbOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOrdenamiento.Location = new Point(480, 25);
            this.cmbOrdenamiento.Name = "cmbOrdenamiento";
            this.cmbOrdenamiento.Size = new Size(180, 23);
            this.cmbOrdenamiento.TabIndex = 4;
            this.cmbOrdenamiento.SelectedIndexChanged += this.cmbOrdenamiento_SelectedIndexChanged;
            // 
            // lblOrdenamiento
            // 
            this.lblOrdenamiento.AutoSize = true;
            this.lblOrdenamiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblOrdenamiento.Location = new Point(400, 28);
            this.lblOrdenamiento.Name = "lblOrdenamiento";
            this.lblOrdenamiento.Size = new Size(73, 15);
            this.lblOrdenamiento.TabIndex = 5;
            this.lblOrdenamiento.Text = "Ordenar por:";
            // 
            // panelTarjetasCategorias
            // 
            this.panelTarjetasCategorias.AutoScroll = true;
            this.panelTarjetasCategorias.BackColor = Color.FromArgb(250, 250, 250);
            this.panelTarjetasCategorias.Location = new Point(300, 60);
            this.panelTarjetasCategorias.Name = "panelTarjetasCategorias";
            this.panelTarjetasCategorias.Size = new Size(700, 540);
            this.panelTarjetasCategorias.TabIndex = 7;
            this.panelTarjetasCategorias.Visible = false;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new Point(300, 60);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new Size(700, 540);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.SelectionChanged += this.dgvProductos_SelectionChanged;
            this.dgvProductos.CellDoubleClick += this.dgvProductos_CellDoubleClick;
            // 
            // panelFormulario
            // 
            this.panelFormulario.BackColor = Color.FromArgb(236, 240, 241);
            this.panelFormulario.Controls.Add(this.btnCancelar);
            this.panelFormulario.Controls.Add(this.btnGuardar);
            this.panelFormulario.Controls.Add(this.cmbCategoria);
            this.panelFormulario.Controls.Add(this.numStock);
            this.panelFormulario.Controls.Add(this.numPrecio);
            this.panelFormulario.Controls.Add(this.txtDescripcion);
            this.panelFormulario.Controls.Add(this.txtNombre);
            this.panelFormulario.Controls.Add(this.txtCodigo);
            this.panelFormulario.Controls.Add(this.pnlCodigoOpciones);
            this.panelFormulario.Controls.Add(this.lblCategoria);
            this.panelFormulario.Controls.Add(this.lblStock);
            this.panelFormulario.Controls.Add(this.lblPrecio);
            this.panelFormulario.Controls.Add(this.lblDescripcion);
            this.panelFormulario.Controls.Add(this.lblNombre);
            this.panelFormulario.Controls.Add(this.lblCodigo);
            this.panelFormulario.Controls.Add(this.lblTitulo);
            this.panelFormulario.Dock = DockStyle.Left;
            this.panelFormulario.Location = new Point(0, 60);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new Size(300, 540);
            this.panelFormulario.TabIndex = 2;
            this.panelFormulario.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(160, 450);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(100, 35);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += this.btnCancelar_Click;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Color.FromArgb(46, 204, 113);
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(40, 450);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(100, 35);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += this.btnGuardar_Click;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Computadoras",
            "Accesorios",
            "Software",
            "Componentes",
            "Periféricos"});
            this.cmbCategoria.Location = new Point(40, 400);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new Size(220, 23);
            this.cmbCategoria.TabIndex = 12;
            // 
            // numStock
            // 
            this.numStock.Location = new Point(40, 360);
            this.numStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new Size(220, 23);
            this.numStock.TabIndex = 11;
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new Point(40, 310);
            this.numPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrecio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new Size(220, 23);
            this.numPrecio.TabIndex = 10;
            this.numPrecio.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Point(40, 220);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = ScrollBars.Vertical;
            this.txtDescripcion.Size = new Size(220, 60);
            this.txtDescripcion.TabIndex = 9;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(40, 170);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(220, 23);
            this.txtNombre.TabIndex = 8;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new Point(40, 120);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new Size(220, 23);
            this.txtCodigo.TabIndex = 7;
            // 
            // pnlCodigoOpciones
            // 
            this.pnlCodigoOpciones.Controls.Add(this.rbCodigoAutomatico);
            this.pnlCodigoOpciones.Controls.Add(this.rbCodigoManual);
            this.pnlCodigoOpciones.Location = new Point(40, 70);
            this.pnlCodigoOpciones.Name = "pnlCodigoOpciones";
            this.pnlCodigoOpciones.Size = new Size(220, 45);
            this.pnlCodigoOpciones.TabIndex = 15;
            // 
            // rbCodigoAutomatico
            // 
            this.rbCodigoAutomatico.AutoSize = true;
            this.rbCodigoAutomatico.Checked = true;
            this.rbCodigoAutomatico.Location = new Point(3, 3);
            this.rbCodigoAutomatico.Name = "rbCodigoAutomatico";
            this.rbCodigoAutomatico.Size = new Size(126, 19);
            this.rbCodigoAutomatico.TabIndex = 0;
            this.rbCodigoAutomatico.TabStop = true;
            this.rbCodigoAutomatico.Text = "Código automático";
            this.rbCodigoAutomatico.UseVisualStyleBackColor = true;
            this.rbCodigoAutomatico.CheckedChanged += this.rbCodigoAutomatico_CheckedChanged;
            // 
            // rbCodigoManual
            // 
            this.rbCodigoManual.AutoSize = true;
            this.rbCodigoManual.Location = new Point(3, 23);
            this.rbCodigoManual.Name = "rbCodigoManual";
            this.rbCodigoManual.Size = new Size(107, 19);
            this.rbCodigoManual.TabIndex = 1;
            this.rbCodigoManual.Text = "Código manual";
            this.rbCodigoManual.UseVisualStyleBackColor = true;
            this.rbCodigoManual.CheckedChanged += this.rbCodigoManual_CheckedChanged;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCategoria.Location = new Point(40, 380);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new Size(63, 15);
            this.lblCategoria.TabIndex = 6;
            this.lblCategoria.Text = "Categoría:";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblStock.Location = new Point(40, 340);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new Size(40, 15);
            this.lblStock.TabIndex = 5;
            this.lblStock.Text = "Stock:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPrecio.Location = new Point(40, 290);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new Size(44, 15);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDescripcion.Location = new Point(40, 200);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(77, 15);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblNombre.Location = new Point(40, 150);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCodigo.Location = new Point(40, 50);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new Size(48, 15);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTitulo.Location = new Point(40, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(126, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Producto";
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.panelTarjetasCategorias);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelTop);
            this.Name = "FormProductos";
            this.Text = "Gestión de Productos";
            this.Load += this.FormProductos_Load;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private ComboBox cmbOrdenamiento;
        private Label lblOrdenamiento;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridView dgvProductos;
        private Panel panelFormulario;
        private Label lblTitulo;
        private Label lblCodigo;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblPrecio;
        private Label lblStock;
        private Label lblCategoria;
        private TextBox txtCodigo;
        private RadioButton rbCodigoAutomatico;
        private RadioButton rbCodigoManual;
        private Panel pnlCodigoOpciones;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private NumericUpDown numPrecio;
        private NumericUpDown numStock;
        private ComboBox cmbCategoria;
        private Button btnGuardar;
        private Button btnCancelar;
        private Panel panelTarjetasCategorias;
        private Button btnVolver;
    }
}