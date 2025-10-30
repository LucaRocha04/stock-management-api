using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using SistemaVentas.Models;

namespace SistemaVentas.Data
{
    public class VentasContext : DbContext
    {
        public VentasContext() { }
        
        public VentasContext(DbContextOptions<VentasContext> options) : base(options) { }
        
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Usamos SQLite temporalmente para evitar problemas de MySQL
                var connectionString = "Data Source=sistema_ventas.db";
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Codigo).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Precio).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Categoria).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Codigo).IsUnique();
            });

            // Configuración de la entidad Venta
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cliente).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DocumentoCliente).HasMaxLength(20);
                entity.Property(e => e.Subtotal).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Impuesto).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Total).HasColumnType("decimal(10,2)");
                entity.Property(e => e.FormaPago).HasMaxLength(20);
                entity.Property(e => e.Observaciones).HasMaxLength(500);
            });

            // Configuración de la entidad DetalleVenta
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Descuento).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(10,2)");

                // Relaciones
                entity.HasOne(d => d.Venta)
                      .WithMany(p => p.DetallesVenta)
                      .HasForeignKey(d => d.VentaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Producto)
                      .WithMany(p => p.DetallesVenta)
                      .HasForeignKey(d => d.ProductoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Datos semilla
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Productos de ejemplo
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Codigo = "PROD001",
                    Nombre = "Laptop Dell Inspiron",
                    Descripcion = "Laptop Dell Inspiron 15, Intel i5, 8GB RAM, 256GB SSD",
                    Precio = 850.00m,
                    Stock = 10,
                    Categoria = "Computadoras",
                    FechaCreacion = DateTime.Now.AddDays(-30)
                },
                new Producto
                {
                    Id = 2,
                    Codigo = "PROD002",
                    Nombre = "Mouse Logitech",
                    Descripcion = "Mouse inalámbrico Logitech MX Master 3",
                    Precio = 45.00m,
                    Stock = 25,
                    Categoria = "Accesorios",
                    FechaCreacion = DateTime.Now.AddDays(-25)
                },
                new Producto
                {
                    Id = 3,
                    Codigo = "PROD003",
                    Nombre = "Teclado Mecánico",
                    Descripcion = "Teclado mecánico retroiluminado RGB",
                    Precio = 75.00m,
                    Stock = 15,
                    Categoria = "Accesorios",
                    FechaCreacion = DateTime.Now.AddDays(-20)
                }
            );
        }
        
        public void InsertSampleData()
        {
            if (!Productos.Any())
            {
                var productos = new[]
                {
                    new Producto
                    {
                        Codigo = "PROD001",
                        Nombre = "Laptop Dell Inspiron",
                        Descripcion = "Laptop Dell Inspiron 15, Intel i5, 8GB RAM, 256GB SSD",
                        Precio = 850.00m,
                        Stock = 10,
                        Categoria = "Computadoras",
                        FechaCreacion = DateTime.Now.AddDays(-30)
                    },
                    new Producto
                    {
                        Codigo = "PROD002",
                        Nombre = "Mouse Logitech",
                        Descripcion = "Mouse inalámbrico Logitech MX Master 3",
                        Precio = 45.00m,
                        Stock = 25,
                        Categoria = "Accesorios",
                        FechaCreacion = DateTime.Now.AddDays(-25)
                    },
                    new Producto
                    {
                        Codigo = "PROD003",
                        Nombre = "Teclado Mecánico",
                        Descripcion = "Teclado mecánico retroiluminado RGB",
                        Precio = 75.00m,
                        Stock = 15,
                        Categoria = "Accesorios",
                        FechaCreacion = DateTime.Now.AddDays(-20)
                    }
                };
                
                Productos.AddRange(productos);
                SaveChanges();
            }
        }
    }
}