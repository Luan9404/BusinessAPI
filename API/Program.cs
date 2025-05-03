using BusinessAPI.Utils.Models;
using BusinessAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessAPI.Service.DependencyInjection;
using BusinessAPI.Domain.DependencyInjection;
using FluentValidation;
using BusinessAPI.Domain.DependencyInjection;
using BusinessAPI.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

builder.Services.AddDbContextPool<AppDBContext>(opt =>
  opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
);

builder.Services.AddValidatorsFromAssembly(
  typeof(Program).Assembly,
  includeInternalTypes: true,
  lifetime: ServiceLifetime.Transient
);
builder.Services.AddUserDomain();
builder.Services.AddUserServices();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();