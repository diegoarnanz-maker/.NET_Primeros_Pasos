using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaApi.Dtos
{
    public class LineaPedidoResponseDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; } // opcional si se hace join
    }
}
