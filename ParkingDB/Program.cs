using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ParkingDBContext>(options =>
    options.UseSqlServer(@"Server=ITLNB089\SQLEXPRESS;Database=ParkingDB;User ID=sa;Password=sa;TrustServerCertificate=True;"));


var app = builder.Build();


app.Run();
