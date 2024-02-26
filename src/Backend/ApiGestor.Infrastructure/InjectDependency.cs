using System.Reflection;
using ApiGestor.Domain;
using ApiGestor.Domain.Repositorio;
using ApiGestor.Domain.Repositorios;
using ApiGestor.Infrastructure.Contexto;
using ApiGestor.Infrastructure.Repositorios;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ApiGestor.Infrastructure;

public static class InjectDependency
{
    public static void AddRepositorio(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
    }

    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddContextoGestor(this IServiceCollection services, IConfiguration configuration)
    {
        string connString = configuration.GetStringConectionWithDatabase();

        services.AddDbContext<ContextoGestor>(
                options => options.
                UseSqlServer(connString));
    }

    public static void AddFluentMigrator(this IServiceCollection services, IConfiguration configuration)
    {
        string connection = configuration.GetStringConectionWithDatabase();

        services.AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSqlServer()
                .WithGlobalConnectionString(connection)
                .ScanIn(Assembly.Load("ApiGestor.Infrastructure"))
            .For.All());
    }
}
