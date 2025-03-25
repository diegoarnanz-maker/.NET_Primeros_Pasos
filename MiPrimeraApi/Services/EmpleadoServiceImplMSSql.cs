using MiPrimeraApi.Models;
using MiPrimeraApi.Repositories;

namespace MiPrimeraApi.Services
{
    // 🔸 Equivale a: @Service public class EmpleadoServiceImplMy8 implements IEmpleadoService
    public class EmpleadoServiceImplMSSql : IEmpleadoService
    {

        //El _ delante de la variable indica que es privada (Buenas practicas en C#)
        private readonly IEmpleadoRepository _repo;

        // 🔹 Equivalente a: @Autowired. Vamos que hace falta constructor para inyectar
        public EmpleadoServiceImplMSSql(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        // 🔸 public List<Empleado> findAll()
        public async Task<List<Empleado>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        // 🔸 public Empleado findById(int id)
        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // 🔸 public Empleado create(Empleado e)
        public async Task<Empleado> CreateAsync(Empleado empleado)
        {
            return await _repo.CreateAsync(empleado);
        }

        // 🔸 public Empleado update(int id, Empleado e)
        public async Task<Empleado> UpdateAsync(int id, Empleado empleado)
        {
            empleado.Id = id; // Aseguramos el ID
            return await _repo.UpdateAsync(empleado);
        }

        // 🔸 public void deleteById(int id)
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
