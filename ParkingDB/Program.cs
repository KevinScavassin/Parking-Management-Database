using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ParkingDBContext>(options =>
    options.UseSqlServer(@"Server=ITLNB089\SQLEXPRESS;Database=ParkingDB;User ID=sa;Password=sa;TrustServerCertificate=True;"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});

app.Run();
