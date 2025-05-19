using ExpenseTracker.Api.Data;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Api.Services.Interfaces;
using ExpenseTracker.Api.Services.Implementations;
using AutoMapper;                   


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Connection string (SQL Server ou SQLite)
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(conn)); // ou UseSqlite(...)

builder.Services.AddControllers();
builder.Services.AddScoped<ICategoryService, CategoryService>();
// ... CORS, AutoMapper, FluentValidation, JWT, etc.

var app = builder.Build();
app.UseRouting();
app.UseCors("AllowAngular");
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();
app.Run();
