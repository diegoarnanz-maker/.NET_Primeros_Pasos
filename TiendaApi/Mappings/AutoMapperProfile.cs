using AutoMapper;
using TiendaApi.Dtos;
using TiendaApi.Models;

namespace TiendaApi.Mappings
{

    /*Hay que ejecutar en terminal:
        - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
        - builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); 
        - using TiendaApi.Mappings;
        En Program.cs
    Esto aniade la dependencia de AutoMapper a nuestro proyecto (TiendaApi.csproj)
    */

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Producto, ProductoResponseDto>();
            CreateMap<ProductoRequestDto, Producto>();

            CreateMap<Pedido, PedidoResponseDto>();
            CreateMap<PedidoRequestDto, Pedido>();

            CreateMap<LineaPedido, LineaPedidoResponseDto>()
                .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Producto.Nombre));

            CreateMap<Pedido, PedidoResponseDto>();

        }
    }
}
