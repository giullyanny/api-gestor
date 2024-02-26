using System.Reflection;
using ApiGestor.Domain;
using ApiGestor.Infrastructure.Migrations;
using ApiGestor.Infrastructure.Migrations.Extension;
using ApiGestor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentMigrator(builder.Configuration);
builder.Services.AddRepositorio();
builder.Services.AddUnitOfWork();
builder.Services.AddContextoGestor(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

builder.Configuration.GetConnectionString("BloggingDatabase");

app.UseAuthorization();

app.MapControllers();

AtualizaBanco();

app.Run();

void AtualizaBanco()
{
    string connString = builder.Configuration.GetStringConection();
    Database.CreateDatabase(connString, "apigestor");

    app.MigrationDataBase();
}