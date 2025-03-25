using MiPrimeraApi.Configurations;
using MiPrimeraApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MiPrimeraApi.Repositories
{
    // 🔹 Equivale a una implementación manual de JpaRepository
    public class EmpleadoRepositoryImpl : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task<Empleado> CreateAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<Empleado> UpdateAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Empleados.FindAsync(id);
            if (emp != null)
            {
                _context.Empleados.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
