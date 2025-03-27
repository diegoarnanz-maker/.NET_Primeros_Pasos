using Microsoft.EntityFrameworkCore;
using TiendaApi.Models;

namespace TiendaApi.Configurations

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mapea la entidad Empleado como una tabla
        // Equivale a @Entity + @Table(name = "Productos") en Java
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Pedido> Pedidos { get; set; } = null!;
        public DbSet<LineaPedido> LineasPedido { get; set; } = null!;

        // Método para configurar detalles del mapeo (como @Column en Java) 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // @Column(precision = 10, scale = 2) en Spring Boot o     @Column(nullable = false, length = 100) por ejemplo
            modelBuilder.Entity<Producto>().Property(p => p.Precio).HasPrecision(10, 2);

            modelBuilder.Entity<LineaPedido>().Property(l => l.PrecioUnitario).HasPrecision(10, 2);

            modelBuilder.Entity<Pedido>().Property(p => p.Total).HasPrecision(10, 2);
        }
    }
}