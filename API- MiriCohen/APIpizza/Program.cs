using Interfaces;
using Services;
using Models;
using fileService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using APIpizza.Extensions;
using APIpizza.Middlewares;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPizza, PizzaService>();
builder.Services.AddTransient<IOrder, OrderService>();
builder.Services.AddScoped<IWorker, WorkerService>();
builder.Services.AddSingleton<IfileService<Pizza>,ReadWrite<Pizza> >();
builder.Services.AddSingleton<IfileService<string>,ReadWrite<string> >();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
    app.UseDefaultFiles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseActionLog();

app.Run();
