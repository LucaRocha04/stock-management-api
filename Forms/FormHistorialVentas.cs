using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using SistemaVentas.Models;

namespace SistemaVentas.Forms
{
    public partial class FormHistorialVentas : Form
    {
        private VentasContext _context;

        public FormHistorialVentas()
        {
            InitializeComponent();
            _context = new VentasContext();
        }

        private void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            CargarVentas();
        }

        // Método público para refrescar desde otros formularios
        public void RefrescarDatos()
        {
            CargarVentas();
        }

        private void InicializarFormulario()
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1); // Incluir todo el día de hoy
            cmbFiltroCliente.SelectedIndex = -1;
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
        }

        private async void CargarVentas()
        {
            try
            {
                Console.WriteLine($"Debug: Cargando ventas desde {dtpDesde.Value.Date:dd/MM/yyyy} hasta {dtpHasta.Value.Date:dd/MM/yyyy}");

                // Primero verificar cuántas ventas hay en total
                var totalVentas = await _context.Ventas.CountAsync();
                var ventasActivas = await _context.Ventas.CountAsync(v => v.Activa);
                Console.WriteLine($"Debug: Total ventas en BD: {totalVentas}, Activas: {ventasActivas}");

                // Verificar las últimas ventas sin filtro de fecha
                var ultimasVentas = await _context.Ventas
                    .Where(v => v.Activa)
                    .OrderByDescending(v => v.Fecha)
                    .Take(3)
                    .Select(v => new { v.Id, v.Fecha, v.Cliente, v.Total })
                    .ToListAsync();

                Console.WriteLine("Debug: Últimas 3 ventas en la BD:");
                foreach (var venta in ultimasVentas)
                {
                    Console.WriteLine($"  ID: {venta.Id}, Cliente: {venta.Cliente}, Fecha: {venta.Fecha:dd/MM/yyyy HH:mm:ss}, Total: {venta.Total}");
                }

                var fechaDesde = dtpDesde.Value.Date;
                var fechaHasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                
                Console.WriteLine($"Debug: Rango de fechas corregido - Desde: {fechaDesde:dd/MM/yyyy HH:mm:ss} Hasta: {fechaHasta:dd/MM/yyyy HH:mm:ss}");

                var query = _context.Ventas
                    .Include(v => v.DetallesVenta)
                    .Where(v => v.Activa && v.Fecha >= fechaDesde && v.Fecha <= fechaHasta);

                // Filtro por cliente si está seleccionado
                if (!string.IsNullOrEmpty(txtFiltroCliente.Text))
                {
                    query = query.Where(v => v.Cliente.Contains(txtFiltroCliente.Text));
                }

                var ventas = await query.OrderByDescending(v => v.Fecha).ToListAsync();
                Console.WriteLine($"Debug: Ventas encontradas con filtros: {ventas.Count}");

                if (ventas.Any())
                {
                    foreach (var v in ventas.Take(5)) // Solo las primeras 5 para no llenar el log
                    {
                        Console.WriteLine($"Debug: Venta ID: {v.Id}, Cliente: {v.Cliente}, Fecha: {v.Fecha:dd/MM/yyyy}, Total: {v.Total}");
                    }
                }

                dgvVentas.DataSource = ventas.Select(v => new
                {
                    v.Id,
                    Fecha = v.Fecha.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = v.Cliente,
                    Documento = v.DocumentoCliente,
                    FormaPago = v.FormaPago,
                    CantidadItems = v.DetallesVenta.Sum(d => d.Cantidad),
                    Subtotal = v.Subtotal.ToString("C"),
                    Impuesto = v.Impuesto.ToString("C"),
                    Total = v.Total.ToString("C"),
                    Observaciones = v.Observaciones
                }).ToList();

                // Ocultar columna ID
                if (dgvVentas.Columns.Contains("Id"))
                    dgvVentas.Columns["Id"].Visible = false;

                // Actualizar estadísticas
                ActualizarEstadisticas(ventas);
                
                // Solo cargar clientes la primera vez o cuando se hace clic en buscar explícitamente
                if (!_clientesCargados)
                {
                    await CargarClientesParaFiltro();
                    _clientesCargados = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Debug: Error en CargarVentas: {ex}");
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _clientesCargados = false;

        private async Task CargarClientesParaFiltro()
        {
            try
            {
                var clientes = await _context.Ventas
                    .Where(v => v.Activa)
                    .Select(v => v.Cliente)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToListAsync();

                // Guardar la selección actual antes de limpiar
                var seleccionActual = cmbFiltroCliente.SelectedItem?.ToString();

                cmbFiltroCliente.Items.Clear();
                cmbFiltroCliente.Items.Add("Todos los clientes");
                foreach (var cliente in clientes)
                {
                    cmbFiltroCliente.Items.Add(cliente);
                }
                
                // Restaurar la selección o seleccionar "Todos" por defecto
                if (!string.IsNullOrEmpty(seleccionActual) && cmbFiltroCliente.Items.Contains(seleccionActual))
                {
                    cmbFiltroCliente.SelectedItem = seleccionActual;
                }
                else
                {
                    cmbFiltroCliente.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadisticas(List<Venta> ventas)
        {
            var totalVentas = ventas.Count;
            var montoTotal = ventas.Sum(v => v.Total);
            var promedioVenta = totalVentas > 0 ? montoTotal / totalVentas : 0;

            // Estadísticas adicionales
            var ventaMaxima = ventas.Any() ? ventas.Max(v => v.Total) : 0;
            var ventaMinima = ventas.Any() ? ventas.Min(v => v.Total) : 0;
            var ventasHoy = ventas.Count(v => v.Fecha.Date == DateTime.Today);

            // Actualizar labels del panel lateral (mantener compatibilidad)
            lblTotalVentas.Text = $"Total Ventas: {totalVentas}";
            lblMontoTotal.Text = $"Monto Total: {montoTotal:C}";
            lblPromedioVenta.Text = $"Promedio por Venta: {promedioVenta:C}";

            // Crear tarjetas estadísticas coloridas
            CrearTarjetasEstadisticas(totalVentas, montoTotal, promedioVenta, ventaMaxima, ventaMinima, ventasHoy);
        }

        private void CrearTarjetasEstadisticas(int totalVentas, decimal montoTotal, decimal promedioVenta, 
                                            decimal ventaMaxima, decimal ventaMinima, int ventasHoy)
        {
            // Limpiar tarjetas existentes
            panelTarjetasVentas.Controls.Clear();

            // Configuración de tarjetas
            int cardWidth = 200, cardHeight = 90, margin = 15;
            int x = 20, y = 15;

            // Tarjeta 1: Total de Ventas
            var cardTotal = CrearTarjetaVenta("🛒 Total Ventas", totalVentas.ToString(), 
                                            Color.FromArgb(52, 152, 219), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetasVentas.Controls.Add(cardTotal);
            x += cardWidth + margin;

            // Tarjeta 2: Monto Total
            var cardMonto = CrearTarjetaVenta("💰 Total Facturado", montoTotal.ToString("C2"), 
                                            Color.FromArgb(46, 204, 113), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetasVentas.Controls.Add(cardMonto);
            x += cardWidth + margin;

            // Tarjeta 3: Promedio por Venta
            var cardPromedio = CrearTarjetaVenta("📊 Promedio", promedioVenta.ToString("C2"), 
                                              Color.FromArgb(155, 89, 182), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetasVentas.Controls.Add(cardPromedio);
            x += cardWidth + margin;

            // Tarjeta 4: Venta Máxima
            var cardMax = CrearTarjetaVenta("⬆️ Mayor Venta", ventaMaxima.ToString("C2"), 
                                          Color.FromArgb(230, 126, 34), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetasVentas.Controls.Add(cardMax);
            x += cardWidth + margin;

            // Tarjeta 5: Ventas de Hoy
            var cardHoy = CrearTarjetaVenta("📅 Ventas Hoy", ventasHoy.ToString(), 
                                          Color.FromArgb(26, 188, 156), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetasVentas.Controls.Add(cardHoy);
            x += cardWidth + margin;

            // Tarjeta 6: Venta Mínima (si cabe)
            if (x + cardWidth < panelTarjetasVentas.Width - 20)
            {
                var cardMin = CrearTarjetaVenta("⬇️ Menor Venta", ventaMinima.ToString("C2"), 
                                              Color.FromArgb(231, 76, 60), Color.White, x, y, cardWidth, cardHeight);
                panelTarjetasVentas.Controls.Add(cardMin);
            }
        }

        private Panel CrearTarjetaVenta(string titulo, string valor, Color colorFondo, Color colorTexto, 
                                      int x, int y, int width, int height)
        {
            var panel = new Panel
            {
                Size = new Size(width, height),
                Location = new Point(x, y),
                BackColor = colorFondo,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = colorTexto,
                BackColor = Color.Transparent,
                Location = new Point(10, 8),
                Size = new Size(width - 20, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblValor = new Label
            {
                Text = valor,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = colorTexto,
                BackColor = Color.Transparent,
                Location = new Point(10, 30),
                Size = new Size(width - 20, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(lblTitulo);
            panel.Controls.Add(lblValor);

            // Efecto hover
            panel.MouseEnter += (s, e) => { 
                panel.BackColor = Color.FromArgb(Math.Min(255, colorFondo.R + 15), 
                                               Math.Min(255, colorFondo.G + 15), 
                                               Math.Min(255, colorFondo.B + 15));
            };
            panel.MouseLeave += (s, e) => { panel.BackColor = colorFondo; };

            return panel;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            // Solo procesar si los clientes ya están cargados
            if (!_clientesCargados) return;

            // Búsqueda en tiempo real con un pequeño delay
            if (_timerBusqueda != null)
            {
                _timerBusqueda.Stop();
                _timerBusqueda.Dispose();
            }

            _timerBusqueda = new System.Windows.Forms.Timer();
            _timerBusqueda.Interval = 500; // 500ms delay
            _timerBusqueda.Tick += (s, ev) =>
            {
                _timerBusqueda.Stop();
                CargarVentas();
            };
            _timerBusqueda.Start();
        }

        private System.Windows.Forms.Timer? _timerBusqueda;

        private void cmbFiltroCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evitar bucles infinitos durante la carga inicial
            if (!_clientesCargados) return;

            if (cmbFiltroCliente.SelectedIndex == 0) // "Todos los clientes"
            {
                txtFiltroCliente.Clear();
                CargarVentas(); // Aplicar filtro inmediatamente
            }
            else if (cmbFiltroCliente.SelectedItem != null)
            {
                var clienteSeleccionado = cmbFiltroCliente.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(clienteSeleccionado) && clienteSeleccionado != "Todos los clientes")
                {
                    txtFiltroCliente.Text = clienteSeleccionado;
                    CargarVentas(); // Aplicar filtro inmediatamente
                }
            }
        }

        private async void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para ver el detalle.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ventaId = (int)dgvVentas.CurrentRow.Cells["Id"].Value;
            await MostrarDetalleVenta(ventaId);
        }

        private async Task MostrarDetalleVenta(int ventaId)
        {
            try
            {
                var venta = await _context.Ventas
                    .Include(v => v.DetallesVenta)
                    .ThenInclude(d => d.Producto)
                    .FirstOrDefaultAsync(v => v.Id == ventaId);

                if (venta != null)
                {
                    var detalleForm = new FormDetalleVenta(venta);
                    detalleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalle de venta: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para anular.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro de anular esta venta?\nEsta acción no se puede deshacer.", 
                                          "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var ventaId = (int)dgvVentas.CurrentRow.Cells["Id"].Value;
                    var venta = await _context.Ventas
                        .Include(v => v.DetallesVenta)
                        .ThenInclude(d => d.Producto)
                        .FirstOrDefaultAsync(v => v.Id == ventaId);

                    if (venta != null)
                    {
                        // Anular venta
                        venta.Activa = false;

                        // Restaurar stock de productos
                        foreach (var detalle in venta.DetallesVenta)
                        {
                            if (detalle.Producto != null)
                            {
                                detalle.Producto.Stock += detalle.Cantidad;
                            }
                        }

                        await _context.SaveChangesAsync();

                        MessageBox.Show("Venta anulada correctamente y stock restaurado.", 
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarVentas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al anular venta: {ex.Message}", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            btnVerDetalle.Enabled = dgvVentas.CurrentRow != null;
            btnEliminar.Enabled = dgvVentas.CurrentRow != null;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarVentas();
            MessageBox.Show("📊 Historial actualizado correctamente", "Actualización", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerBusqueda?.Dispose();
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}