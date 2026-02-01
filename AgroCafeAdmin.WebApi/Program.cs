using AgroCafeAdmin.Data.Data;
using AgroCafeAdmin.Data.Injection;
using AgroCafeAdmin.Service.Seguridad;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configurar Entity Framework con SQL Server
builder.Services.AddDbContext<AgroCafeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.MigrationsAssembly("AgroCafeAdmin.Data")
    ));

builder.Services.AddDataLayer(builder.Configuration);


// Agregar capa de servicios
builder.Services.AddScoped<IAutorizacionService, AutorizacionService>();
builder.Services.AddScoped<ITokenService, TokenService>(); // Asegúrate de tener esta línea

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
