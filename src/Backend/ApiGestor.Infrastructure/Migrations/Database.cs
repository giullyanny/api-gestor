using System.Data.SqlClient;
using Dapper;

namespace ApiGestor.Infrastructure.Migrations;

public static class Database
{
    public static void CreateDatabase(string stringConnection, string nameDataBase)
    {
        using SqlConnection connection = new SqlConnection(stringConnection);
        
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("nome", nameDataBase);

        var registros = connection.Query("SELECT [name], database_id, create_date FROM sys.databases where [name] = @nome", parameters);

        if (!registros.Any())
        {
            connection.Execute($"CREATE DATABASE {nameDataBase}");
        }
    }
}
