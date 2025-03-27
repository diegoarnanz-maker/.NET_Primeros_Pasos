using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaApi.Configurations;
using TiendaApi.Models;

namespace TiendaApi.Repositories
{
    public class PedidoRepositoryImpl : IPedidoRepository
    {

        private readonly AppDbContext _context;

        public PedidoRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Pedido>> GetAllAsync()
        {
            try
            {
                return await _context.Pedidos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pedidos", ex);
            }
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID no puede ser menor o igual a 0", nameof(id));

            try
            {
                return await _context.Pedidos.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el pedido", ex);
            }
        }

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo");
            try
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el pedido", ex);
            }
        }

        public async Task<Pedido> UpdateAsync(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo");

            try
            {
                // el ? es como optional de java
                Pedido? pedidoExistente = await _context.Pedidos.FindAsync(pedido.Id);

                if (pedidoExistente == null)
                    throw new InvalidOperationException($"No se encontró el pedido con ID {pedido.Id}");

                _context.Update(pedidoExistente);
                await _context.SaveChangesAsync();

                return pedidoExistente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pedido", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID no puede ser menor o igual a 0", nameof(id));

            try
            {
                bool existe = await _context.Pedidos.AnyAsync(p => p.Id == id);

                if (!existe)
                    throw new InvalidOperationException($"No se encontró ningún pedido con ID: {id}");

                Pedido pedido = new Pedido { Id = id };
                _context.Pedidos.Remove(pedido);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el pedido con ID: {id}", ex);
            }
        }

    }
}