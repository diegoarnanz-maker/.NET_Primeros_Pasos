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

    }
}

