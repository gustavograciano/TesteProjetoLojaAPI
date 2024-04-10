using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TesteProjetoLojaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add database configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Retrieve the connection string from appsettings.json
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Configure the DbContext to use SQL Server with the connection string
    options.UseSqlServer(connectionString, sqlServerOptions =>
    {
        sqlServerOptions.CommandTimeout(60); // Configuração opcional do tempo limite de comando SQL
        sqlServerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); // Configuração opcional de tentativas de conexão
    });
});

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

// Enable CORS
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000"); // Permitir requisições de qualquer origem
    options.AllowAnyMethod(); // Permitir qualquer método (GET, POST, PUT, DELETE, etc.)
    options.AllowAnyHeader(); // Permitir qualquer cabeçalho HTTP
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
