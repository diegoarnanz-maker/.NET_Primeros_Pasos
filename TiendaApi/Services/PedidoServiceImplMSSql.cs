using Microsoft.EntityFrameworkCore;
using TiendaApi.Configurations;
using TiendaApi.Dtos;
using TiendaApi.Models;
using TiendaApi.Services;

namespace TiendaApi.Services
{
    public class PedidoServiceImplMSSql : IPedidoService
    {
        private readonly AppDbContext _context;

        public PedidoServiceImplMSSql(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> CreateAsync(Pedido pedido, List<LineaPedidoRequestDto> lineas)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo");

            if (lineas == null || lineas.Count == 0)
                throw new ArgumentException("Debe haber al menos una línea de pedido", nameof(lineas));

            decimal total = 0;

            foreach (LineaPedidoRequestDto linea in lineas)
            {
                Producto? producto = await _context.Productos.FindAsync(linea.IdProducto);

                if (producto == null)
                    throw new ArgumentException($"Producto con ID {linea.IdProducto} no encontrado");

                decimal subtotal = producto.Precio * linea.Cantidad;
                total += subtotal;

                LineaPedido nuevaLinea = new LineaPedido
                {
                    IdProducto = linea.IdProducto,
                    Cantidad = linea.Cantidad,
                    PrecioUnitario = producto.Precio
                };

                pedido.Lineas.Add(nuevaLinea);
            }

            pedido.Total = total;

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos
                // Oye, cuando busques un Pedido, también quiero que traigas sus LineasPedido relacionadas
                .Include(p => p.Lineas)
                // Para cada LineaPedido, tráeme también el Producto relacionado.
                .ThenInclude(lp => lp.Producto)
                // Devuelve el primer pedido que cumpla con ese ID
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pedido> UpdateAsync(int id, Pedido pedido)
        {
            pedido.Id = id;
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }
    }
}
