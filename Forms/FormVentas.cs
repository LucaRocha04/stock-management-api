using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using SistemaVentas.Models;

namespace SistemaVentas.Forms
{
    public partial class FormVentas : Form
    {
        private VentasContext _context;
        private List<DetalleVenta> _detallesVenta;
        private decimal _totalVenta = 0;

        public FormVentas()
        {
            InitializeComponent();
            _context = new VentasContext();
            _detallesVenta = new List<DetalleVenta>();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            dtpFecha.Value = DateTime.Now;
            cmbFormaPago.SelectedIndex = 0;
            ConfigurarDataGridView();
            CargarProductos();
            ConfigurarAutocompletadoCliente();
        }

        private async void ConfigurarAutocompletadoCliente()
        {
            try
            {
                // Cargar clientes existentes para autocompletado
                var clientes = await _context.Ventas
                    .Where(v => v.Activa && !string.IsNullOrEmpty(v.Cliente))
                    .Select(v => v.Cliente)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToListAsync();

                var autoComplete = new AutoCompleteStringCollection();
                autoComplete.AddRange(clientes.ToArray());

                txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCliente.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                // Si hay error, continuar sin autocompletado
                Console.WriteLine($"Error configurando autocompletado: {ex.Message}");
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.Columns.Add("ProductoId", "ID Producto");
            dgvDetalle.Columns.Add("Codigo", "Código");
            dgvDetalle.Columns.Add("Nombre", "Producto");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("PrecioUnitario", "Precio Unit.");
            dgvDetalle.Columns.Add("Descuento", "Descuento %");
            dgvDetalle.Columns.Add("Subtotal", "Subtotal");

            dgvDetalle.Columns["ProductoId"].Visible = false;
            dgvDetalle.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void CargarProductos()
        {
            try
            {
                var productos = await _context.Productos
                    .Where(p => p.Activo && p.Stock > 0)
                    .OrderBy(p => p.Nombre)
                    .ToListAsync();

                cmbProducto.DataSource = productos;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "Id";
                cmbProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem is Producto producto)
            {
                txtCodigo.Text = producto.Codigo;
                numPrecio.Value = producto.Precio;
                lblStock.Text = $"Stock: {producto.Stock}";
                numCantidad.Maximum = producto.Stock;
                numCantidad.Value = 1;
                CalcularSubtotal();
            }
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void numPrecio_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void numDescuento_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            var subtotal = (numPrecio.Value * numCantidad.Value) * (1 - numDescuento.Value / 100);
            lblSubtotal.Text = $"Subtotal: {subtotal:C2}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarProducto()) return;

            var producto = (Producto?)cmbProducto.SelectedItem;
            if (producto == null) return;

            var detalle = new DetalleVenta
            {
                ProductoId = producto.Id,
                Producto = producto,
                Cantidad = (int)numCantidad.Value,
                PrecioUnitario = numPrecio.Value,
                Descuento = numDescuento.Value
            };
            detalle.Subtotal = detalle.Total;

            _detallesVenta.Add(detalle);
            ActualizarDataGridView();
            CalcularTotalVenta();
            LimpiarSeleccionProducto();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                var indice = dgvDetalle.CurrentRow.Index;
                _detallesVenta.RemoveAt(indice);
                ActualizarDataGridView();
                CalcularTotalVenta();
            }
        }

        private void ActualizarDataGridView()
        {
            dgvDetalle.Rows.Clear();
            foreach (var detalle in _detallesVenta)
            {
                dgvDetalle.Rows.Add(
                    detalle.ProductoId,
                    detalle.Producto.Codigo,
                    detalle.Producto.Nombre,
                    detalle.Cantidad,
                    detalle.PrecioUnitario,
                    detalle.Descuento,
                    detalle.Subtotal
                );
            }
        }

        private void CalcularTotalVenta()
        {
            var subtotal = _detallesVenta.Sum(d => d.Subtotal);
            var impuesto = subtotal * 0.18m; // IVA 18%
            _totalVenta = subtotal + impuesto;

            lblSubtotalVenta.Text = $"Subtotal: {subtotal:C2}";
            lblImpuesto.Text = $"Impuesto (18%): {impuesto:C2}";
            lblTotalVenta.Text = $"TOTAL: {_totalVenta:C2}";
        }

        private async void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (!ValidarVenta()) return;

            try
            {
                var venta = new Venta
                {
                    Fecha = dtpFecha.Value,
                    Cliente = txtCliente.Text.Trim(),
                    DocumentoCliente = txtDocumento.Text.Trim(),
                    FormaPago = cmbFormaPago.Text,
                    Observaciones = txtObservaciones.Text.Trim(),
                    Subtotal = _detallesVenta.Sum(d => d.Subtotal),
                    Impuesto = _detallesVenta.Sum(d => d.Subtotal) * 0.18m,
                    Total = _totalVenta,
                    Activa = true
                };

                Console.WriteLine($"Debug: Creando venta para cliente: {venta.Cliente}, Total: {venta.Total}");

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                Console.WriteLine($"Debug: Venta guardada con ID: {venta.Id}");

                // Agregar detalles
                foreach (var detalle in _detallesVenta)
                {
                    detalle.VentaId = venta.Id;
                    _context.DetallesVenta.Add(detalle);

                    // Actualizar stock
                    var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                    if (producto != null)
                    {
                        producto.Stock -= detalle.Cantidad;
                    }
                }

                await _context.SaveChangesAsync();
                Console.WriteLine($"Debug: {_detallesVenta.Count} detalles guardados para la venta ID: {venta.Id}");

                // Verificar que se guardó correctamente
                var ventaVerificacion = await _context.Ventas
                    .Include(v => v.DetallesVenta)
                    .FirstOrDefaultAsync(v => v.Id == venta.Id);
                
                Console.WriteLine($"Debug: Verificación - Venta encontrada: {ventaVerificacion != null}, Detalles: {ventaVerificacion?.DetallesVenta.Count ?? 0}");

                // Mostrar mensaje de éxito con más información
                var mensaje = $"✅ VENTA REGISTRADA EXITOSAMENTE\n\n" +
                             $"🎫 ID de Venta: {venta.Id}\n" +
                             $"👤 Cliente: {venta.Cliente}\n" +
                             $"📅 Fecha: {venta.Fecha:dd/MM/yyyy HH:mm}\n" +
                             $"📦 Items: {_detallesVenta.Count} productos\n" +
                             $"💰 Total: {_totalVenta:C2}";

                MessageBox.Show(mensaje, "¡Venta Guardada!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Preguntar si quiere ver el historial de ventas
                var resultado = MessageBox.Show("¿Desea ver el historial de ventas actualizado?", 
                                              "Historial de Ventas", 
                                              MessageBoxButtons.YesNo, 
                                              MessageBoxIcon.Question);
                
                if (resultado == DialogResult.Yes)
                {
                    var formHistorial = new FormHistorialVentas();
                    formHistorial.Show();
                }

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Debug: Error al guardar venta: {ex}");
                MessageBox.Show($"Error al registrar venta: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_detallesVenta.Count > 0)
            {
                var resultado = MessageBox.Show("¿Está seguro de cancelar la venta?", 
                                              "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    LimpiarFormulario();
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtCliente.Clear();
            txtDocumento.Clear();
            txtObservaciones.Clear();
            dtpFecha.Value = DateTime.Now;
            cmbFormaPago.SelectedIndex = 0;
            _detallesVenta.Clear();
            ActualizarDataGridView();
            CalcularTotalVenta();
            LimpiarSeleccionProducto();
        }

        private void LimpiarSeleccionProducto()
        {
            cmbProducto.SelectedIndex = -1;
            txtCodigo.Clear();
            numPrecio.Value = 0;
            numCantidad.Value = 1;
            numDescuento.Value = 0;
            lblStock.Text = "Stock: 0";
            lblSubtotal.Text = "Subtotal: $0.00";
        }

        private bool ValidarProducto()
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProducto.Focus();
                return false;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return false;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrecio.Focus();
                return false;
            }

            // Verificar que haya stock suficiente
            var producto = (Producto?)cmbProducto.SelectedItem;
            if (producto != null)
            {
                var cantidadYaAgregada = _detallesVenta
                    .Where(d => d.ProductoId == producto.Id)
                    .Sum(d => d.Cantidad);
                
                var cantidadTotal = cantidadYaAgregada + (int)numCantidad.Value;
                
                if (cantidadTotal > producto.Stock)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {producto.Stock}, ya agregado: {cantidadYaAgregada}", 
                                  "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numCantidad.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ValidarVenta()
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("El cliente es requerido.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return false;
            }

            if (_detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Validación", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}