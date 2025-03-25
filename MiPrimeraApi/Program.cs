using Microsoft.EntityFrameworkCore;
using MiPrimeraApi.Configurations;
using MiPrimeraApi.Repositories;
using MiPrimeraApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔸 Equivalente a la clase Application con @SpringBootApplication en Java
// Aquí comienza la configuración de la app, como en Spring con SpringApplication.run(...)


// 🔹 Configurar la conexión a base de datos (como application.properties en Spring Boot)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// En Spring Boot harías esto con propiedades:
// spring.datasource.url=jdbc:...
// spring.datasource.username=...
// spring.jpa.hibernate.ddl-auto=...


// 🔹 Registrar la capa de repositorio e inyectarla (como usar @Repository en Spring)
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepositoryImpl>();
// En Spring: @Repository + interfaz que extiende JpaRepository

// 🔹 Registrar el servicio de negocio (como @Service en Spring Boot)
builder.Services.AddScoped<IEmpleadoService, EmpleadoServiceImplMSSql>();
// En Spring: @Service + @Autowired del repositorio


// 🔹 Configurar CORS — permite que Angular o Postman puedan hacer peticiones
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// En Spring Boot sería un WebMvcConfigurer con addCorsMappings()


// 🔹 Habilita los controladores REST (como @RestController en Spring Boot)
builder.Services.AddControllers();
// En Spring Boot esto se hace automáticamente con @RestController + @SpringBootApplication

// 🔹 Swagger: genera documentación de tu API como en SpringFox o SpringDoc
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// En Spring Boot necesitarías una clase de configuración + dependencias para Swagger


// 🔸 Construye la app — igual que el ApplicationContext de Spring
var app = builder.Build();


// 🔹 Solo activar Swagger si estás en modo desarrollo (como usar profiles en Spring)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// En Spring usarías @Profile("dev") para cargar configuración condicional


// 🔹 Fuerza redirección a HTTPS — útil si usas certificados
app.UseHttpsRedirection();
// Equivale a server.ssl.enabled=true en Spring + redirecciones configuradas


// 🔹 Aplica la política de CORS que definimos antes
app.UseCors("PermitirTodo");
// En Spring: registry.addMapping("/**").allowedOrigins("*")


// 🔹 Middleware de autorización (aunque no uses login aún)
// En Spring se activa con @EnableWebSecurity + filtros
app.UseAuthorization();


// 🔹 Mapea las rutas REST definidas en tus controladores
app.MapControllers();
// Equivale a escanear y registrar @RestController + @RequestMapping


// 🔸 Lanza la aplicación web (como SpringApplication.run)
app.Run();
