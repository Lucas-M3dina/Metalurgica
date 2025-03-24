using Metalurgica.Data;
using Metalurgica.Data.Repositories;
using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Shared.Services.Interfaces;
using Metalurgica.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);



// Injeção de dependências
builder.Services.AddDbContext<MetalurgicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoQuesitoRepository, ProdutoQuesitoRepository>();
builder.Services.AddScoped<IEmbalagemRepository, EmbalagemRepository>();
builder.Services.AddScoped<IQuesitoRepository, QuesitoRepository>();
builder.Services.AddScoped<IProdutoEmbalagemRepository, ProdutoEmbalagemRepository>();
builder.Services.AddScoped<ILoteRepository, LoteRepository>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IEmbalagemService, EmbalagemService>();
builder.Services.AddScoped<IQuesitoService, QuesitoService>();
builder.Services.AddScoped<ILoteService, LoteService>();


// Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

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
