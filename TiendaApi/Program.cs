using Microsoft.EntityFrameworkCore;
using TiendaApi.Configurations; // 🔹 Para AppDbContext
using TiendaApi.Repositories;
using TiendaApi.Services;
using TiendaApi.Mappings;       // 🔹 Para AutoMapperProfile

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configurar conexión a SQL Server (como DataSource en Spring)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Registrar servicios personalizados (como @Service y @Repository en Spring)
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryImpl>();
builder.Services.AddScoped<IProductoService, ProductoServiceImplMSSql>();

builder.Services.AddScoped<IPedidoService, PedidoServiceImplMSSql>();

// 🔹 Registrar AutoMapper (como ModelMapper en Java)
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// 🔹 Servicios de ASP.NET Core
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Middlewares de seguridad y rutas
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // 🔸 Como @RequestMapping en Spring

app.Run(); // 🔚 Arranca la API
