using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es requerido")]
        [StringLength(20)]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [StringLength(50)]
        public string Categoria { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;

        // Navegación - Relación con ventas
        public virtual ICollection<DetalleVenta> DetallesVenta { get; set; } = new List<DetalleVenta>();

        // Propiedad calculada
        [NotMapped]
        public decimal ValorStock => Precio * Stock;
    }
}