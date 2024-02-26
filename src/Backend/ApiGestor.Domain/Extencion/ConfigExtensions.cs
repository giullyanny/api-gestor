using Microsoft.Extensions.Configuration;
using System;

namespace ApiGestor.Domain;

public static class ConfigExtensions
{
    public static string GetStringConection(this IConfiguration configurationManager)
    {
        // Verifica no ambiente
        string chave = "conexao";
        string valorChave = Environment.GetEnvironmentVariable(chave) ?? "";

        if (String.IsNullOrEmpty(valorChave))
        {
            // Se não encontrado no ambiente, busca no appsettings.json
            valorChave = configurationManager.GetConnectionString(chave) ?? "";
        }


        return valorChave;
    }

    public static string GetDataBase(this IConfiguration configurationManager, string chave)
    {
        // Verifica no ambiente
        string valorChave = Environment.GetEnvironmentVariable(chave) ?? "";

        if (String.IsNullOrEmpty(valorChave))
        {
            // Se não encontrado no ambiente, busca no appsettings.json
            valorChave = configurationManager.GetConnectionString(chave) ?? "";
        }


        return valorChave;
    }

    public static string GetStringConectionWithDatabase(this IConfiguration configurationManager)
    {
        // Verifica no ambiente
        string database = GetDataBase(configurationManager, "database");
        string connectionString = GetStringConection(configurationManager);

        connectionString += $"Database={database};";

        return connectionString;
    }
}