using Microsoft.Extensions.Configuration;
using WebApp.DAL.Models;
using WebApp.DAL.Repository;
using WebApp.DAL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApp.Service;
using WebApp.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FinanceContext>(options =>
    options.UseSqlServer(@"Server=DESKTOP-L4JH3JT\SQLEXPRESS;Database=task12DB;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
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
