using Microsoft.Extensions.Configuration;
using System;

namespace ApiGestor.Domain;

public static class ConfigExtensions
{
    public static string GetStringConection(this ConfigurationManager configurationManager, string chave)
    {
        // Verifica no ambiente
        string? valorAmbiente = Environment.GetEnvironmentVariable(chave);

        if (!String.IsNullOrEmpty(valorAmbiente))
        {
            return valorAmbiente;
        }

        // Se não encontrado no ambiente, busca no appsettings.json
        string? valorAppSettings = configurationManager.GetConnectionString(chave);

        return valorAppSettings;
    }
}