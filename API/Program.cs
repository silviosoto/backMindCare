using API.Models;
using API.Services;
using Data.Contracts;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API;
using Microsoft.OpenApi.Models;
using BLL.PsicologoBll;
using DAL.Repositorys;
using BLL.Automapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BLL.Servicio;
using DAL.Contracts;
using BLL.HobbiesBLL;
using BLL.UserBLL;
using BLL.Contracts;
using QuestPDF.Infrastructure;
using BLL;
using BLL.Factura;


// Configurar la licencia gratuita de QuestPDF
QuestPDF.Settings.License = LicenseType.Community;
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

builder.Services.AddScoped<IPsicologoRepository, PsicologoRepositorio>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<IHobbies, HobbiesRepository>();
builder.Services.AddScoped<IAgenda, AgendaRepository>();
builder.Services.AddScoped<ICita, CitaRepository>();
builder.Services.AddScoped<IPacienteRepository,PacienteRepository>();
builder.Services.AddScoped<ISala,SalaRepository>();
builder.Services.AddScoped<IPayment,PaymentRepository>();
builder.Services.AddScoped<IUser,UsuarioRepository>();


// Repository
builder.Services.AddScoped(typeof(Repository<>));

builder.Services.AddScoped<PsicologoRepositorio>();
builder.Services.AddScoped<ServicioRepository>();
builder.Services.AddScoped<PsicologoService>();
builder.Services.AddScoped<ServicioService>();
builder.Services.AddScoped<HobbiesRepository>();
builder.Services.AddScoped<HobbiesSevices>();
builder.Services.AddScoped<AgendaRepository>();
builder.Services.AddScoped<AgendaSevices>();
builder.Services.AddScoped<PacienteRepository>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<CitaRepository>();
builder.Services.AddScoped<CitasServices>();
builder.Services.AddScoped<SalaRepository>();
builder.Services.AddScoped<SalaSevices>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<PaymentSevices>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IFacturaService, BLL.Factura.FacturaSevices>();
builder.Services.AddScoped<ICarritoDeCompraRepository, CarritoDeCompraRepository>();
builder.Services.AddScoped<ICarroDeCompraService, CarritoDeCompraSevices>();
builder.Services.AddScoped<ITerapiaRepository, TerapiaRepository>();
builder.Services.AddScoped<ITerapiaService, TerapiaSevices>();
builder.Services.AddScoped<IHistoriaclinicaRepository, HistoriaclinicaRepository>();
builder.Services.AddScoped<IHistoriaClinicaService, HistoriaclinicaSevices>();
builder.Services.AddScoped<ISignosFisicosRepository, SignosFisicosRepository>();
builder.Services.AddScoped<ISignosFisicosService, SignosFisicosService>();
builder.Services.AddScoped<IMentalPersonalRepository, MentalPersonalRepository>();
builder.Services.AddScoped<IMentalPersonalService, MentalPersonalService>();
builder.Services.AddScoped<IHistoriaAcademicaRepository, HistoriaAcademicaRepository>();
builder.Services.AddScoped<IHistoriaAcademicaService, HistoriaAcademicaService>();
builder.Services.AddScoped<IRazonesSintomasConductaRepository, RazonesSintomasConductaRepository>();
builder.Services.AddScoped<IRazonesSintomasConductaService, RazonesSintomasConductaService>();
builder.Services.AddScoped<IDesarrolloPsicosexualRepository, DesarrolloPsicosexualRepository>();
builder.Services.AddScoped<IDesarrolloPsicosexualService, DesarrolloPsicosexualService>();
builder.Services.AddScoped<IExamenEstadoMentalRepository, ExamenEstadoMentalRepository>();
builder.Services.AddScoped<IExamenEstadoMentalService, ExamenEstadoMentalService>();
builder.Services.AddScoped<IConceptoPsicologicoRepository, ConceptoPsicologicoRepository>();
builder.Services.AddScoped<IConceptoPsicologicoService, ConceptoPsicologicoService>();

//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddHttpClient();
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddScoped<IAzureStorageService, AzureStorageService>();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
  {
    {
    new OpenApiSecurityScheme
    {
      Reference = new OpenApiReference
      {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
      },
      Scheme = "Jwt",
      Name = "Bearer",
      In = ParameterLocation.Header,
    },
    new List<string>()
    }
  });
});

builder.Services.AddSingleton<IJwtAuthManager, JwtAuthManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();
// Habilitar archivos estáticos desde wwwroot
app.UseStaticFiles();

app.UseCors(x => x
    .WithOrigins("https://mindcere.azurewebsites.net", "http://localhost:3000", "*", "https://mindcareappvc.daily.co", "http://localhost:4200") // allow any origin
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
