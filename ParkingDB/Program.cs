using Microsoft.EntityFrameworkCore;
using ParkingDB.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ParkingDBContext>(options =>
    options.UseSqlServer(@"Server=ITLNB089\SQLEXPRESS;Database=ParkingDB;Trusted_Connection=True;TrustServerCertificate=True;"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
}
else
{
    app.UseExceptionHandler("/Home/Error"); 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run(); 
