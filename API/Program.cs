using API.Models;
using API.Services;
using Data.Contracts;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Domain.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
//var connectionString = Environment.GetEnvironmentVariable("defaultConnection");
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
builder.Services.AddDbContext<DbmindCareContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddScoped<IAzureStorageService, AzureStorageService>();


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .WithOrigins("https://mindcere.azurewebsites.net", "http://localhost:3000", "*") // allow any origin
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()); // allow credentials



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
