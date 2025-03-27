using Microsoft.EntityFrameworkCore;
using TiendaApi.Configurations;
using TiendaApi.Models;

namespace TiendaApi.Repositories
{
    // Responsabilidad: acceder directamente a la base de datos mediante Entity Framework Core
    public class ProductoRepositoryImpl : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            try
            {
                return await _context.Productos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los productos", ex);
            }
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0", nameof(id));

            try
            {
                return await _context.Productos.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el producto con ID {id}", ex);
            }
        }

        public async Task<Producto> CreateAsync(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo");

            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el producto", ex);
            }
        }

        public async Task<Producto> UpdateAsync(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo");

            try
            {
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que 0", nameof(id));

            try
            {
                Producto? producto = await _context.Productos.FindAsync(id);
                if (producto == null)
                    throw new InvalidOperationException($"No se encontró el producto con ID: {id}");

                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el producto con ID: {id}", ex);
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return await _context.Productos.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar los productos", ex);
            }
        }

        public async Task<List<Producto>> GetPagedAsync(int page, int pageSize)
        {
            if (page <= 0 || pageSize <= 0)
                throw new ArgumentException("La página y el tamaño deben ser mayores que 0");

            try
            {
                return await _context.Productos
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos paginados", ex);
            }
        }
    }
}
