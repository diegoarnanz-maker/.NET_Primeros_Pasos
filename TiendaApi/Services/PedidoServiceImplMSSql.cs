using Microsoft.EntityFrameworkCore;
using TiendaApi.Configurations;
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

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
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
            return await _context.Pedidos.FindAsync(id);
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
