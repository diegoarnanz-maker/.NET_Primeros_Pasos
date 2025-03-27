using Microsoft.EntityFrameworkCore;
using TiendaApi.Configurations;
using TiendaApi.Models;

namespace TiendaApi.Repositories
{
    //Responsabilidad: acceder directamente a la base de datos mediante Entity Framework Core
    public class ProductoRepositoryImpl : IProductoRepository
    {
        // Inyección del DbContext
        //EF Core lo utiliza para acceder a las tablas (DbSet<Producto>) y ejecutar las operaciones CRUD

        // @Repository
        // public interface ProductoRepository extends JpaRepository<Producto, Integer> { }

        private readonly AppDbContext _context;

        public ProductoRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        //

        // Métodos CRUD
        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        // EF a diferencia que JPA no tiene un método save que sirva para insertar y actualizar
        // En EF se debe usar Add para insertar y Update para actualizar
        public async Task<Producto> CreateAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _context.Productos.FindAsync(id);
            if (p != null)
            {
                _context.Productos.Remove(p);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync()
        {
            return await _context.Productos.CountAsync();
        }

        public async Task<List<Producto>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Productos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
