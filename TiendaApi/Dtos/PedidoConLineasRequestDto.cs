using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaApi.Dtos
{
    public class PedidoConLineasRequestDto
    {
        public List<LineaPedidoRequestDto> Lineas { get; set; } = new();
    }
}

