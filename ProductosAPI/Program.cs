using Microsoft.EntityFrameworkCore;
using ProductosAPI.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("Conexion");
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseSqlServer(connectionString); // Configura el proveedor de base de datos que necesites
});

// Add services to the container.

builder.Services.AddControllers();
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
