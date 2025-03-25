using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Models;
using MiPrimeraApi.Services;

namespace MiPrimeraApi.Controllers
{
    // 🔹 Equivalente a @RestController en Spring Boot
    // En .NET, se usa [ApiController] para indicar que este controlador trabaja con JSON y maneja una API REST
    // No existe una distinción entre @Controller y @RestController como en Java

    [ApiController]

    // 🔹 Equivale a @RequestMapping("/api/empleado")
    // El token [controller] será reemplazado por el nombre del controlador sin el sufijo "Controller"
    // Por ejemplo, EmpleadoController => ruta base: /api/empleado
    [Route("api/[controller]")]

    // 🔹 En .NET, los controladores que devuelven JSON heredan de ControllerBase
    // Si quisieras devolver vistas (como Razor o Blazor), heredarías de Controller
    public class EmpleadoController : ControllerBase

    //  Diferencias con ResponseEntity en Spring Boot:
    // return Ok(objeto);             // 200 OK
    // return NotFound();             // 404 Not Found
    // return CreatedAtAction(...);   // 201 Created
    // return BadRequest();           // 400 Bad Request
    // return NoContent();            // 204 No Content

    {
        private readonly IEmpleadoService _service;

        // 🔹 Equivalente a: @Autowired en Spring
        // Aquí se inyecta el servicio por constructor, que es el patrón estándar en .NET
        public EmpleadoController(IEmpleadoService service)
        {
            _service = service;
        }

        // 🔹 GET /api/empleado
        // Equivalente a: @GetMapping en Spring
        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetAll()
        {
            var empleados = await _service.GetAllAsync();
            return Ok(empleados); // 🔸 Devuelve 200 OK + lista de empleados en JSON
        }

        // 🔹 GET /api/empleado/{id}
        // Equivalente a: @GetMapping("/{id}")
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetById(int id)
        {
            var empleado = await _service.GetByIdAsync(id);
            if (empleado == null)
                return NotFound(); // 🔸 Devuelve 404 si no existe
            return Ok(empleado);
        }

        // 🔹 POST /api/empleado
        // Equivalente a: @PostMapping
        [HttpPost]
        public async Task<ActionResult<Empleado>> Create(Empleado empleado)
        {
            var nuevo = await _service.CreateAsync(empleado);

            // 🔸 Devuelve 201 Created + ubicación del nuevo recurso
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        // 🔹 PUT /api/empleado/{id}
        // Equivalente a: @PutMapping("/{id}")
        [HttpPut("{id}")]
        public async Task<ActionResult<Empleado>> Update(int id, Empleado empleado)
        {
            var actualizado = await _service.UpdateAsync(id, empleado);
            return Ok(actualizado);
        }

        // 🔹 DELETE /api/empleado/{id}
        // Equivalente a: @DeleteMapping("/{id}")
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent(); // 🔸 Devuelve 204 No Content
        }
    }
}
