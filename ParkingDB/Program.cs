using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;
using ParkingDB.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ParkingDBContext>(options =>
    options.UseSqlServer(@"Server=ITLNB089\SQLEXPRESS;Database=ParkingDB;User ID=sa;Password=sa;TrustServerCertificate=True;"));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ParkingDBContext>();
        DatabaseData.Initialize(context); 
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao inicializar o banco de dados: " + ex.Message);
    }
}

app.Run();
