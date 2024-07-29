using System;
using Register.Database;
using Register.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Register.Domain.Services.GuardianService;
using Register.Domain.Services.RelationshipService;
using Register.Domain.Services.ReportService;
using Register.Domain.Services.WardService;
using Register.Infrastructure.Repositories.Guardians;
using Register.Infrastructure.Repositories.Relationships;
using Register.Infrastructure.Repositories.Wards;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgresConnectionString") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddPostgres(connectionString);

builder.Services.AddScoped<IWardService, WardService>();
builder.Services.AddScoped<IWardRepository, WardRepository>();

builder.Services.AddScoped<IGuardianService, GuardianService>();
builder.Services.AddScoped<IGuardianRepository, GuardianRepository>();

builder.Services.AddScoped<IRelationshipService, RelationshipService>();
builder.Services.AddScoped<IRelationshipRepository, RelationshipRepository>();

builder.Services.AddScoped<IReportService, ReportService>();
// builder.Services.AddScoped<IRelationshipRepository, RelationshipRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.WithOrigins(
    "http://localhost:7156",
    "https://localhost:7156")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();