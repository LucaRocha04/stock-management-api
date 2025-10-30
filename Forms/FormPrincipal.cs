using SistemaVentas.Forms;

namespace SistemaVentas.Forms
{
    public partial class FormPrincipal : Form
    {
        private System.Windows.Forms.Timer timerFecha;

        public FormPrincipal()
        {
            InitializeComponent();
            InicializarTimer();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarFecha();
            lblStatus.Text = "Sistema iniciado correctamente";
            MostrarPantallaInicio();
        }

        private void MostrarPantallaInicio()
        {
            // Limpiar el panel principal
            panelPrincipal.Controls.Clear();
            
            // Crear pantalla de bienvenida
            CrearPantallaBienvenida();
            lblStatus.Text = "Panel de control principal";
        }

        private void CrearPantallaBienvenida()
        {
            // Panel contenedor principal
            var panelBienvenida = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(50)
            };

            // Título principal
            var lblTitulo = new Label
            {
                Text = "🏪 SISTEMA DE VENTAS Y STOCK",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true,
                Location = new Point(100, 80)
            };

            // Subtítulo
            var lblSubtitulo = new Label
            {
                Text = "Gestión completa de productos, ventas y reportes",
                Font = new Font("Segoe UI", 16),
                ForeColor = Color.FromArgb(127, 140, 141),
                AutoSize = true,
                Location = new Point(100, 130)
            };

            // Panel de tarjetas de acceso rápido
            var panelTarjetas = new Panel
            {
                Size = new Size(800, 300),
                Location = new Point(100, 200),
                BackColor = Color.Transparent
            };

            // Crear tarjetas de acceso rápido
            CrearTarjetaAcceso(panelTarjetas, "📦 PRODUCTOS", "Gestionar inventario", 
                              Color.FromArgb(52, 152, 219), 0, () => gestionarProductosToolStripMenuItem_Click(this, EventArgs.Empty));
            
            CrearTarjetaAcceso(panelTarjetas, "💰 VENTAS", "Nueva venta", 
                              Color.FromArgb(46, 204, 113), 200, () => nuevaVentaToolStripMenuItem_Click(this, EventArgs.Empty));
            
            CrearTarjetaAcceso(panelTarjetas, "📊 REPORTES", "Ver estadísticas", 
                              Color.FromArgb(155, 89, 182), 400, () => ventasMensualesToolStripMenuItem_Click(this, EventArgs.Empty));
            
            CrearTarjetaAcceso(panelTarjetas, "📋 HISTORIAL", "Ver historial", 
                              Color.FromArgb(231, 76, 60), 600, () => historialVentasToolStripMenuItem_Click(this, EventArgs.Empty));

            // Información del sistema
            var lblInfo = new Label
            {
                Text = $"Sistema iniciado el {DateTime.Now:dd/MM/yyyy} • Versión 1.0",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(149, 165, 166),
                AutoSize = true,
                Location = new Point(100, 520)
            };

            // Agregar controles al panel
            panelBienvenida.Controls.AddRange(new Control[] { 
                lblTitulo, lblSubtitulo, panelTarjetas, lblInfo 
            });
            
            panelPrincipal.Controls.Add(panelBienvenida);
        }

        private void CrearTarjetaAcceso(Panel contenedor, string titulo, string descripcion, Color color, int x, Action accion)
        {
            var tarjeta = new Panel
            {
                Size = new Size(180, 120),
                Location = new Point(x, 20),
                BackColor = color,
                Cursor = Cursors.Hand
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 20)
            };

            var lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 50)
            };

            var lblClick = new Label
            {
                Text = "Click para acceder →",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 85)
            };

            tarjeta.Controls.AddRange(new Control[] { lblTitulo, lblDescripcion, lblClick });
            tarjeta.Click += (s, e) => accion?.Invoke();
            
            // Agregar evento click a todos los controles hijos
            foreach (Control control in tarjeta.Controls)
            {
                control.Click += (s, e) => accion?.Invoke();
            }

            contenedor.Controls.Add(tarjeta);
        }

        private void InicializarTimer()
        {
            timerFecha = new System.Windows.Forms.Timer();
            timerFecha.Interval = 1000; // 1 segundo
            timerFecha.Tick += TimerFecha_Tick;
            timerFecha.Start();
        }

        private void TimerFecha_Tick(object? sender, EventArgs e)
        {
            ActualizarFecha();
        }

        private void ActualizarFecha()
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPantallaInicio();
        }

        private void gestionarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormProductos());
            lblStatus.Text = "Gestionando productos";
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormVentas());
            lblStatus.Text = "Registrando nueva venta";
        }

        private void historialVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormHistorialVentas());
            lblStatus.Text = "Consultando historial de ventas";
        }

        private void ventasMensualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormGraficos("ventas_mensuales"));
            lblStatus.Text = "Visualizando ventas mensuales";
        }

        private void productosMasVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormGraficos("productos_vendidos"));
            lblStatus.Text = "Visualizando productos más vendidos";
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            // Limpiar panel principal
            panelPrincipal.Controls.Clear();

            // Configurar formulario como control
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Agregar al panel
            panelPrincipal.Controls.Add(formulario);
            formulario.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerFecha?.Stop();
            timerFecha?.Dispose();
            base.OnFormClosed(e);
        }
    }
}