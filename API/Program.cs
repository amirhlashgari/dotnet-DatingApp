using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}); // registers DBContext as service

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

builder.Services.AddCors(); // adding cors headers
// builder.Services.AddSingleton ---> used for injecting them as singleton(service lifetime scoped)
// builder.Services.AddTransient ---> keeps instance after complete
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));
app.MapControllers();

app.Run();


// USEFUL CLI COMMANDS:
/* 
    1- dotnet new list {-h}
    2- dotnet new {program}
    3- dotnet dev-certs https --ckeck
    4- dotnet dev-certs https --clean ---> removes current certificate
    5- dotnet dev-certs https --trust ---> create new certificate
    6- dotnet tool list -g
    7- dotnet ef migrations -h ---> entity framework related command, should its tool be installed
    8- dotnet ef migrations add InitialCreate -o Data/Migrations ---> create automatic migrations using ef
    9- dotnet ef database update ---> creates database based on migrations
*/