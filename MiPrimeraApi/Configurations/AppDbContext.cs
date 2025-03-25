using Microsoft.EntityFrameworkCore; // Similar a javax.persistence o Spring Data
using MiPrimeraApi.Models;           // Como importar tus entidades

namespace MiPrimeraApi.Configurations // Como tu paquete config en Spring Boot
{
    // 🔹 Esta clase es como tu EntityManager + JpaConfig en Java
    public class AppDbContext : DbContext
    {
        // 🔸 Constructor con configuración de conexión (como DataSource + JPAProperties)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 🔹 Esto mapea la entidad Empleado como una tabla
        public DbSet<Empleado> Empleados { get; set; }
        // Equivale a @Entity + @Table(name = "Empleados") en Java

        // 🔸 Método para configurar detalles del mapeo (como @Column en Java)
        // Aquí puedes indicar que "Salario" es decimal(10,2) en SQL Server
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Equivalente a: @Column(precision = 10, scale = 2) en Spring Boot
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasPrecision(10, 2);

            // 🔸 Aquí podrías seguir añadiendo configuraciones para otras entidades
            // modelBuilder.Entity<Categoria>()...
        }
    }
}
