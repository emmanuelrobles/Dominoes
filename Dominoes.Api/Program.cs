using Dominoes.Api.Configuration;
using Dominoes.Application.Repositories;
using Dominoes.Application.Services;
using Dominoes.Core;
using Dominoes.MongoDb.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Gets the configuration
var mongoConfig = builder.Configuration.GetSection("MongoDb").Get<MongoConfig>();

// Register Jornada Repo
builder.Services.AddTransient<IJornadaRepository>(_ =>
    new JornadaRepository(mongoConfig.ConnectionString, mongoConfig.DatabaseName, mongoConfig.JornadaCollectionName));
// Register Dominoes service
builder.Services.AddTransient<DominoesService>();

// Cors
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// handles cors
app.UseCors(b =>
{
    b
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();