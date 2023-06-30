using Infrastructure.Extensions.ApplicationBuilder;
using Infrastructure.Extensions.ServiceCollection;
using Infrastructure.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

// Linea de configuracion del perfil de automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(AutoMapperProfile).Assembly);
// Se agrega opsiones de los controladores para evitar referecnias ciruclares y ajustar zona horaria
builder.Services.AddControllersExtend();
// Agrega ctx de la base de datos
builder.Services.AddDbContext(builder.Configuration);
/* Implementaciones del tipo Factory. */
builder.Services.AddDbFactory();
// Contenedor de inversion de control (IoC)
builder.Services.AddDependency();
// Metodo de autenticacion
builder.Services.AddAuthenticationExtend(builder.Configuration.GetSection("JWT:Key").Value);

var app = builder.Build();

//Configuracion inicial
DefaultCfg.InitConfigurationApi(app);

app.Run();
