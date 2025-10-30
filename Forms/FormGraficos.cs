using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using System.Linq;

namespace SistemaVentas.Forms
{
    public partial class FormGraficos : Form
    {
        private VentasContext _context;
        private string _tipoGrafico;

        public FormGraficos()
        {
            InitializeComponent();
            _context = new VentasContext();
            _tipoGrafico = "ventas";
        }

        public FormGraficos(string tipoGrafico)
        {
            InitializeComponent();
            _context = new VentasContext();
            _tipoGrafico = tipoGrafico;
            CargarDatos();
        }

        private void FormGraficos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            switch (_tipoGrafico.ToLower())
            {
                case "productos":
                    CargarEstadisticasProductos();
                    break;
                default:
                    CargarEstadisticasVentas();
                    break;
            }
        }

        private async void CargarEstadisticasVentas()
        {
            try
            {
                // Limpiar tarjetas anteriores
                panelTarjetas.Controls.Clear();
                
                // Actualizar título
                lblTitulo.Text = "📊 Reportes de Ventas";
                this.Text = "📊 Reportes de Ventas";
                
                // Obtener estadísticas de ventas
                var fechaInicio = DateTime.Now.AddMonths(-12);
                var ventas = await _context.Ventas
                    .Where(v => v.Activa && v.Fecha >= fechaInicio)
                    .ToListAsync();

                if (!ventas.Any())
                {
                    lblEstadisticas.Text = "📊 No hay ventas registradas en los últimos 12 meses.\n\nComience registrando algunas ventas para ver estadísticas detalladas.";
                    return;
                }

                var totalVentas = ventas.Sum(v => v.Total);
                var cantidadVentas = ventas.Count;
                var promedioVenta = totalVentas / cantidadVentas;
                var mayorVenta = ventas.Max(v => v.Total);
                var menorVenta = ventas.Min(v => v.Total);

                // Crear tarjetas de estadísticas principales
                CrearTarjetasVentas(totalVentas, cantidadVentas, promedioVenta, mayorVenta, menorVenta);

                // Ventas por mes
                var ventasPorMes = ventas
                    .GroupBy(v => new { v.Fecha.Year, v.Fecha.Month })
                    .Select(g => new
                    {
                        Periodo = $"{GetNombreMes(g.Key.Month)} {g.Key.Year}",
                        Total = g.Sum(v => v.Total),
                        Cantidad = g.Count()
                    })
                    .OrderByDescending(x => x.Total)
                    .Take(5)
                    .ToList();

                var estadisticas = $@"
╔════════════════════════════════════════════════════════════════╗
║                    📊 ESTADÍSTICAS DE VENTAS                   ║
║                     (Últimos 12 meses)                        ║
╚════════════════════════════════════════════════════════════════╝

┌─ 💰 RESUMEN GENERAL ────────────────────────────────────────────┐
│                                                                 │
│  💵 Total vendido:          {totalVentas:C2}                     
│  🛒 Número de ventas:       {cantidadVentas} transacciones       
│  📊 Promedio por venta:     {promedioVenta:C2}                   
│  ⬆️  Venta mayor:           {mayorVenta:C2}                      
│  ⬇️  Venta menor:           {menorVenta:C2}                      
│                                                                 │
└─────────────────────────────────────────────────────────────────┘

┌─ 📈 TOP 5 MESES CON MAYORES VENTAS ────────────────────────────┐
│                                                                 │";

                int posicion = 1;
                foreach (var mes in ventasPorMes)
                {
                    string medalla = posicion switch
                    {
                        1 => "🥇",
                        2 => "🥈", 
                        3 => "🥉",
                        _ => "🏆"
                    };
                    estadisticas += $"\n│  {medalla} {posicion}º {mes.Periodo.PadRight(20)} {mes.Total:C2} ({mes.Cantidad} ventas)";
                    posicion++;
                }

                estadisticas += @"
│                                                                 │
└─────────────────────────────────────────────────────────────────┘";

                lblEstadisticas.Text = estadisticas;
            }
            catch (Exception ex)
            {
                lblEstadisticas.Text = $"Error al cargar estadísticas: {ex.Message}";
            }
        }

        private async void CargarEstadisticasProductos()
        {
            try
            {
                // Limpiar tarjetas anteriores
                panelTarjetas.Controls.Clear();
                
                // Actualizar título
                lblTitulo.Text = "📦 Reportes de Productos";
                this.Text = "📦 Reportes de Productos";
                
                // Obtener estadísticas de productos
                var productos = await _context.Productos.Where(p => p.Activo).ToListAsync();
                var detallesVenta = await _context.DetallesVenta
                    .Include(d => d.Producto)
                    .Include(d => d.Venta)
                    .Where(d => d.Venta.Activa)
                    .ToListAsync();

                if (!productos.Any())
                {
                    lblEstadisticas.Text = "📦 No hay productos registrados.\n\nComience agregando productos al inventario para ver estadísticas detalladas.";
                    return;
                }

                var totalProductos = productos.Count;
                var productosSinStock = productos.Where(p => p.Stock == 0).Count();
                var productosStockBajo = productos.Where(p => p.Stock > 0 && p.Stock < 10).Count();
                var valorInventario = productos.Sum(p => p.Stock * p.Precio);
                
                // Categoría con más productos
                var categoriaTop = productos
                    .GroupBy(p => p.Categoria)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault()?.Key ?? "N/A";

                // Crear tarjetas de estadísticas de productos
                CrearTarjetasProductos(totalProductos, valorInventario, productosStockBajo, productosSinStock, categoriaTop);

                // Productos más vendidos para el área de texto
                var productosVendidos = detallesVenta
                    .GroupBy(d => new { d.ProductoId, d.Producto.Nombre })
                    .Select(g => new
                    {
                        Producto = g.Key.Nombre,
                        CantidadVendida = g.Sum(d => d.Cantidad),
                        MontoTotal = g.Sum(d => d.Subtotal)
                    })
                    .OrderByDescending(x => x.CantidadVendida)
                    .Take(10)
                    .ToList();

                var estadisticas = "🏆 TOP PRODUCTOS MÁS VENDIDOS\n\n";
                
                if (productosVendidos.Any())
                {
                    int posicion = 1;
                    foreach (var producto in productosVendidos)
                    {
                        string medalla = posicion switch
                        {
                            1 => "🥇",
                            2 => "🥈", 
                            3 => "🥉",
                            _ => "📦"
                        };
                        
                        estadisticas += $"{medalla} {posicion}º {producto.Producto}\n";
                        estadisticas += $"    📊 {producto.CantidadVendida} unidades vendidas\n";
                        estadisticas += $"    💰 {producto.MontoTotal:C2} generados\n\n";
                        posicion++;
                    }
                }
                else
                {
                    estadisticas += "ℹ️ No hay ventas registradas aún.\n\nComience realizando ventas para ver qué productos son más populares.";
                }

                lblEstadisticas.Text = estadisticas;
            }
            catch (Exception ex)
            {
                lblEstadisticas.Text = $"Error al cargar estadísticas: {ex.Message}";
            }
        }

        private void CrearTarjetasVentas(decimal totalVentas, int cantidadVentas, decimal promedioVenta, decimal mayorVenta, decimal menorVenta)
        {
            // Limpiar tarjetas existentes
            panelTarjetas.Controls.Clear();

            // Configuración de tarjetas
            int cardWidth = 180, cardHeight = 120, margin = 15;
            int x = 20, y = 20;

            // Tarjeta 1: Total Vendido
            var cardTotal = CrearTarjeta("💰 Total Vendido", totalVentas.ToString("C2"), 
                                      Color.FromArgb(46, 204, 113), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardTotal);
            x += cardWidth + margin;

            // Tarjeta 2: Número de Ventas
            var cardCantidad = CrearTarjeta("🛒 Transacciones", cantidadVentas.ToString(), 
                                         Color.FromArgb(52, 152, 219), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardCantidad);
            x += cardWidth + margin;

            // Tarjeta 3: Promedio por Venta
            var cardPromedio = CrearTarjeta("📊 Promedio", promedioVenta.ToString("C2"), 
                                         Color.FromArgb(155, 89, 182), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardPromedio);
            x += cardWidth + margin;

            // Tarjeta 4: Venta Mayor
            var cardMayor = CrearTarjeta("⬆️ Venta Mayor", mayorVenta.ToString("C2"), 
                                      Color.FromArgb(230, 126, 34), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardMayor);
            x += cardWidth + margin;

            // Tarjeta 5: Venta Menor
            var cardMenor = CrearTarjeta("⬇️ Venta Menor", menorVenta.ToString("C2"), 
                                      Color.FromArgb(231, 76, 60), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardMenor);
        }

        private void CrearTarjetasProductos(int totalProductos, decimal valorInventario, int stockBajo, int sinStock, string categoriaTop)
        {
            // Limpiar tarjetas existentes
            panelTarjetas.Controls.Clear();

            // Configuración de tarjetas
            int cardWidth = 180, cardHeight = 120, margin = 15;
            int x = 20, y = 20;

            // Tarjeta 1: Total Productos
            var cardTotal = CrearTarjeta("📦 Total Productos", totalProductos.ToString(), 
                                      Color.FromArgb(52, 152, 219), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardTotal);
            x += cardWidth + margin;

            // Tarjeta 2: Valor del Inventario
            var cardValor = CrearTarjeta("💰 Valor Total", valorInventario.ToString("C2"), 
                                       Color.FromArgb(46, 204, 113), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardValor);
            x += cardWidth + margin;

            // Tarjeta 3: Stock Bajo
            var cardStockBajo = CrearTarjeta("⚠️ Stock Bajo", stockBajo.ToString(), 
                                           Color.FromArgb(230, 126, 34), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardStockBajo);
            x += cardWidth + margin;

            // Tarjeta 4: Sin Stock
            var cardSinStock = CrearTarjeta("🚫 Sin Stock", sinStock.ToString(), 
                                          Color.FromArgb(231, 76, 60), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardSinStock);
            x += cardWidth + margin;

            // Tarjeta 5: Categoría Top
            var cardCategoriaTop = CrearTarjeta("🏆 Categoría Top", categoriaTop, 
                                             Color.FromArgb(155, 89, 182), Color.White, x, y, cardWidth, cardHeight);
            panelTarjetas.Controls.Add(cardCategoriaTop);
        }

        private Panel CrearTarjeta(string titulo, string valor, Color colorFondo, Color colorTexto, int x, int y, int width, int height)
        {
            var panel = new Panel
            {
                Size = new Size(width, height),
                Location = new Point(x, y),
                BackColor = colorFondo,
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand
            };

            // Agregar un borde redondeado visual con otro panel
            var panelBorde = new Panel
            {
                Size = new Size(width - 4, height - 4),
                Location = new Point(2, 2),
                BackColor = colorFondo,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = colorTexto,
                BackColor = Color.Transparent,
                Location = new Point(15, 15),
                Size = new Size(width - 30, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblValor = new Label
            {
                Text = valor,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = colorTexto,
                BackColor = Color.Transparent,
                Location = new Point(15, 45),
                Size = new Size(width - 30, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panelBorde.Controls.Add(lblTitulo);
            panelBorde.Controls.Add(lblValor);
            panel.Controls.Add(panelBorde);

            // Efecto hover
            panel.MouseEnter += (s, e) => { 
                panel.BackColor = Color.FromArgb(Math.Min(255, colorFondo.R + 20), 
                                               Math.Min(255, colorFondo.G + 20), 
                                               Math.Min(255, colorFondo.B + 20));
            };
            panel.MouseLeave += (s, e) => { panel.BackColor = colorFondo; };

            return panel;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            _tipoGrafico = "ventas";
            CargarEstadisticasVentas();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            _tipoGrafico = "productos";
            CargarEstadisticasProductos();
        }

        private string GetNombreMes(int mes)
        {
            string[] meses = { "", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                              "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            return meses[mes];
        }
    }
}