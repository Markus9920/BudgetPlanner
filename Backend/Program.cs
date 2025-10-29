

using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Models;
using BudgetPlanner.Backend.Service;
using BudgetPlanner.Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;



var builder = WebApplication.CreateBuilder(args);



//database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Database/database.db"));

// Add services to the container.
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<UserService>();
builder.Services.AddControllers();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //use swagger in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

OpenSwagger("https://localhost:61124/swagger/");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//method to open browser in swagger UI
static void OpenSwagger(string url)
{
    try
    {
        var psi = new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        };
        Process.Start(psi);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error opening Swagger {ex}");
    }
}

