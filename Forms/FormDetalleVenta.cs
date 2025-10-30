using SistemaVentas.Models;

namespace SistemaVentas.Forms
{
    public partial class FormDetalleVenta : Form
    {
        private Venta _venta;

        public FormDetalleVenta(Venta venta)
        {
            InitializeComponent();
            _venta = venta;
        }

        private void FormDetalleVenta_Load(object sender, EventArgs e)
        {
            CargarDatosVenta();
        }

        private void CargarDatosVenta()
        {
            // Información de la venta
            lblNumeroVenta.Text = $"Venta #{_venta.Id:000000}";
            lblFecha.Text = $"Fecha: {_venta.Fecha:dd/MM/yyyy HH:mm}";
            lblCliente.Text = $"Cliente: {_venta.Cliente}";
            lblDocumento.Text = $"Documento: {_venta.DocumentoCliente ?? "N/A"}";
            lblFormaPago.Text = $"Forma de Pago: {_venta.FormaPago}";
            lblObservaciones.Text = $"Observaciones: {_venta.Observaciones ?? "N/A"}";

            // Totales
            lblSubtotal.Text = $"Subtotal: {_venta.Subtotal:C}";
            lblImpuesto.Text = $"Impuesto: {_venta.Impuesto:C}";
            lblTotal.Text = $"TOTAL: {_venta.Total:C}";

            // Detalles
            dgvDetalles.DataSource = _venta.DetallesVenta.Select(d => new
            {
                Código = d.Producto.Codigo,
                Producto = d.Producto.Nombre,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario.ToString("C"),
                Descuento = d.Descuento.ToString("P2"),
                Subtotal = d.Subtotal.ToString("C")
            }).ToList();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión no implementada.", 
                          "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}