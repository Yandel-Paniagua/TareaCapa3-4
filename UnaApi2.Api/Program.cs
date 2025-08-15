
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.Mapping;
using UnaApi2.Application.Services;
using UnaApi2.Infrastructure.Context;
using UnaApi2.Infrastructure.Core;
using UnaApi2.Infrastructure.Interfaces;
using UnaApi2.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.\

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddDbContext<UnaApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IConsejosClimaticoRepository, ConsejosClimaticoRepository>();
builder.Services.AddScoped<IConsejosClimaticoService, ConsejosClimaticoService>();
builder.Services.AddScoped<ILecturasClimaticaRepository, LecturasClimaticaRepository>();
builder.Services.AddScoped<ILecturasClimaticaService, LecturasClimaticaService>();
builder.Services.AddScoped<IAlertasMeteorologicaRepository, AlertasMeteorologicaRepository>(); 
builder.Services.AddScoped<IAlertasMeteorologicaService, AlertasMeteorologicaService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()   // Permitir cualquier origen
            .AllowAnyMethod()   // Permitir cualquier método (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader();  // Permitir cualquier cabecera
    });
});

builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors("AllowAll");

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
