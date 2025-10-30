using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El cliente es requerido")]
        [StringLength(100)]
        public string Cliente { get; set; } = string.Empty;

        [StringLength(20)]
        public string? DocumentoCliente { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Impuesto { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [StringLength(20)]
        public string FormaPago { get; set; } = "Efectivo";

        [StringLength(500)]
        public string? Observaciones { get; set; }

        public bool Activa { get; set; } = true;

        // Navegación - Relación con detalles de venta
        public virtual ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();

        // Propiedad calculada
        [NotMapped]
        public int TotalItems => DetallesVenta?.Sum(d => d.Cantidad) ?? 0;
    }

    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VentaId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100")]
        public decimal Descuento { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        // Navegación
        [ForeignKey("VentaId")]
        public virtual Venta Venta { get; set; } = null!;

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; } = null!;

        // Propiedad calculada
        [NotMapped]
        public decimal Total => (PrecioUnitario * Cantidad) * (1 - Descuento / 100);
    }
}