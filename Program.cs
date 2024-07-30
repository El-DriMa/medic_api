using medic_api.Data;
using medic_api.Mappings;
using medic_api.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MedicLabServer")));

builder.Services.AddScoped<IUserRepository, SQLUserRepository>();

builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

builder.Services.AddCors(options => options.AddPolicy(name: "FrontUI", policy =>
{
    policy.WithOrigins("https://medicapi.azurewebsites.net/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors();

app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
