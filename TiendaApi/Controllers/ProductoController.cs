using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaApi.Dtos;
using TiendaApi.Models;
using TiendaApi.Services;

// 🔸 Controlador tradicional similar a los de Spring Boot
namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // 🔸 GET /api/producto
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ProductoResponseDto>>>> GetAll()
        {
            List<Producto> productos = await _service.GetAllAsync();
            List<ProductoResponseDto> productosDto = _mapper.Map<List<ProductoResponseDto>>(productos);
            return Ok(new ApiResponse<List<ProductoResponseDto>>("Listado total de productos", productosDto));
        }

        // 🔸 GET /api/producto/paged?page=1&pageSize=3
        [HttpGet("paged")]
        public async Task<ActionResult<PagedResponse<ProductoResponseDto>>> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 3)
        {
            PagedResponse<Producto> pagedProductos = await _service.GetPagedAsync(page, pageSize);
            List<ProductoResponseDto> productosDto = _mapper.Map<List<ProductoResponseDto>>(pagedProductos.Data);

            PagedResponse<ProductoResponseDto> response = new PagedResponse<ProductoResponseDto>(
                pagedProductos.Message,
                productosDto,
                pagedProductos.TotalItems,
                pagedProductos.Page,
                pagedProductos.PageSize
            );

            return Ok(response);
        }

        // 🔸 GET /api/producto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductoResponseDto>>> GetById(int id)
        {
            Producto? producto = await _service.GetByIdAsync(id);

            if (producto == null)
            {
                return NotFound(new ApiResponse<string>($"No se encontró el producto con ID {id}"));
            }

            ProductoResponseDto productoDto = _mapper.Map<ProductoResponseDto>(producto);
            return Ok(new ApiResponse<ProductoResponseDto>("Producto encontrado", productoDto));
        }

        // 🔸 POST /api/producto
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProductoResponseDto>>> Create([FromBody] ProductoRequestDto productoDto)
        {
            Producto producto = _mapper.Map<Producto>(productoDto);
            Producto productoCreado = await _service.CreateAsync(producto);
            ProductoResponseDto responseDto = _mapper.Map<ProductoResponseDto>(productoCreado);

            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id },
                new ApiResponse<ProductoResponseDto>("Producto creado correctamente", responseDto));
        }

        // 🔸 PUT /api/producto/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ProductoResponseDto>>> Update(int id, [FromBody] ProductoRequestDto request)
        {
            Producto producto = _mapper.Map<Producto>(request);
            Producto? actualizado = await _service.UpdateAsync(id, producto);

            if (actualizado == null)
                return NotFound(new ApiResponse<string>($"Producto con ID {id} no encontrado"));

            ProductoResponseDto dto = _mapper.Map<ProductoResponseDto>(actualizado);
            return Ok(new ApiResponse<ProductoResponseDto>("Producto actualizado correctamente", dto));
        }

        // 🔸 DELETE /api/producto/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            Producto? producto = await _service.GetByIdAsync(id);

            if (producto == null)
                return NotFound(new ApiResponse<string>($"Producto con ID {id} no encontrado"));

            await _service.DeleteAsync(id);
            return Ok(new ApiResponse<object>($"Producto con ID {id} eliminado correctamente", new { id }));
        }
    }
}
