using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaApi.Dtos;
using TiendaApi.Models;
using TiendaApi.Services;

namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // [ApiController] + ControllerBase es el equivalente a @RestController
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<PedidoResponseDto>>>> GetAll()
        {
            List<Pedido> pedidos = await _pedidoService.GetAllAsync();
            List<PedidoResponseDto> pedidosDto = _mapper.Map<List<PedidoResponseDto>>(pedidos);

            return Ok(new ApiResponse<List<PedidoResponseDto>>("Listado total de pedidos", pedidosDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PedidoResponseDto>>> GetById(int id)
        {
            Pedido? pedido = await _pedidoService.GetByIdAsync(id);

            if (pedido == null)
            {
                return NotFound(new ApiResponse<string>($"Pedido con ID {id} no encontrado"));
            }

            PedidoResponseDto pedidoDto = _mapper.Map<PedidoResponseDto>(pedido);
            return Ok(new ApiResponse<PedidoResponseDto>("Pedido encontrado", pedidoDto));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<PedidoResponseDto>>> Create([FromBody] PedidoConLineasRequestDto dto)
        {
            Pedido pedido = new Pedido();

            Pedido nuevoPedido = await _pedidoService.CreateAsync(pedido, dto.Lineas);

            PedidoResponseDto pedidoDto = _mapper.Map<PedidoResponseDto>(nuevoPedido);

            return CreatedAtAction(nameof(GetById), new { id = pedidoDto.Id },
                new ApiResponse<PedidoResponseDto>("Pedido creado correctamente", pedidoDto));
        }

    }
}

