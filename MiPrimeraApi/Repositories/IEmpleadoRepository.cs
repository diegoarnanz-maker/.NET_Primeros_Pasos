using MiPrimeraApi.Models;

namespace MiPrimeraApi.Repositories
{
    // 🔸 Equivalente a: public interface IVacanteRepository { ... }
    // Aquí definimos el contrato de acceso a datos

    public interface IEmpleadoRepository
    {
        // 🔸 public List<Empleado> findAll();
        Task<List<Empleado>> GetAllAsync();

        // 🔸 public Empleado findById(int id);
        Task<Empleado?> GetByIdAsync(int id);

        // 🔸 public Empleado save(Empleado e);
        Task<Empleado> CreateAsync(Empleado empleado);

        // 🔸 public Empleado update(Empleado e);
        Task<Empleado> UpdateAsync(Empleado empleado);

        // 🔸 public void deleteById(int id);
        Task DeleteAsync(int id);
    }
}
