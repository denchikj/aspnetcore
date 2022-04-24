using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal.WebApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    var projectDirectory = AppContext.BaseDirectory;

    var projectName = Assembly.GetExecutingAssembly().GetName().Name;
    var xmlFileName = $"{projectName}.xml";

    options.IncludeXmlComments(Path.Combine(projectDirectory, xmlFileName));
});
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = configuration.GetConnectionString("PostgreSQL");
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.Run();

