using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

builder.Services.AddDbContextPool<AppDBContext>(opt =>
  opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
);

builder.Services.AddUserServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();