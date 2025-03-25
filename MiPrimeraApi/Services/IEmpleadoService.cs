using MiPrimeraApi.Models;

namespace MiPrimeraApi.Services
{
    // 🔸 Equivalente en Java:
    // public interface EmpleadoService {
    //     List<Empleado> findAll();
    //     Empleado findById(int id);
    //     Empleado create(Empleado empleado);
    //     Empleado update(int id, Empleado empleado);
    //     void delete(int id);
    // }

    // 🔹 Esta interfaz define el contrato del servicio de negocio, como en Java
    public interface IEmpleadoService
    {
        // 🔸 public List<Empleado> findAll();
        // Aquí usamos 'Task<List<Empleado>>' porque es asincrónico
        Task<List<Empleado>> GetAllAsync();

        // 🔸 public Empleado findById(int id);
        // El '?' indica que puede devolver null (como Optional en Java 8+)
        Task<Empleado?> GetByIdAsync(int id);

        // 🔸 public Empleado create(Empleado empleado);
        // En Java sería un método POST que guarda una entidad
        Task<Empleado> CreateAsync(Empleado empleado);

        // 🔸 public Empleado update(int id, Empleado empleado);
        // Igual que en Java, se actualiza la entidad por su ID
        Task<Empleado> UpdateAsync(int id, Empleado empleado);

        // 🔸 public void delete(int id);
        // En Java eliminarías por ID
        Task DeleteAsync(int id);
    }
}
