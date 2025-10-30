
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BudgetPlanner.Backend.Database;
using BudgetPlanner.Backend.Models;
using BudgetPlanner.Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BudgetPlanner.Backend.Interfaces;



var builder = WebApplication.CreateBuilder(args);



//database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddControllers();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(o =>
  {
      o.TokenValidationParameters = new()
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer   = builder.Configuration["Jwt:Issuer"],
          ValidAudience = builder.Configuration["Jwt:Audience"],
          ClockSkew = TimeSpan.Zero,
          IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
      };
  });



builder.Services.AddAuthorization();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
Console.WriteLine("Issuer: " + builder.Configuration["Jwt:Issuer"]);
Console.WriteLine("Audience: " + builder.Configuration["Jwt:Audience"]);
Console.WriteLine("Key length: " + builder.Configuration["Jwt:Key"]?.Length);
Console.WriteLine("Expires: " + builder.Configuration["Jwt:ExpirationInMinutes"]);
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

