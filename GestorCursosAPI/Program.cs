using GestorCursosAPI.Data;
using Microsoft.EntityFrameworkCore;
using GestorCursosAPI.Repositories;
using GestorCursosAPI.Services;
using GestorCursosAPI.Repositories.CursoRepository;
using GestorCursosAPI.Services.CursoServices;
using GestorCursosAPI.Repositories.EstudianteRepository;
using GestorCursosAPI.Services.EstudianteServices;
using GestorCursosAPI.Services.Relaciones.CursoEstudianteServices;
using GestorCursosAPI.Mappings;
using GestorCursosAPI.Repositories.CategoriaRepository;
using GestorCursosAPI.Services.CategoriaServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GestorCursosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();

builder.Services.AddScoped<ICursoEstudianteService, CursoEstudianteService>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

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
