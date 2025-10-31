using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MotoRentManager.Application.Common.Interfaces;
using MotoRentManager.Application.Motos.Commands;
using MotoRentManager.Application.Motos.Commands.Validators;
using MotoRentManager.Infra.Data;
using MotoRentManager.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<IMotoRepository, MotoRepository>();

builder.Services.AddScoped<ICommandHandler<CadastrarMotoCommand>, CadastrarMotoCommnandHandler>();

builder.Services.AddValidatorsFromAssemblyContaining< CadastrarMotoCommandValidator>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
