using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace ApiGestor.Infrastructure.Migrations;

public static class VersionBase
{
    public static void InserirColunaPadrao(ref ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
        table.WithColumn("id").AsGuid().NotNullable().WithDefaultValue(SystemMethods.NewGuid)
            .WithColumn("data_criacao").AsDateTime().NotNullable().WithDefaultValue(DateTime.Parse("1800-01-01"));
    }
}
