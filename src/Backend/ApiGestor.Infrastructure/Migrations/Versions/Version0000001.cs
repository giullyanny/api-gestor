using FluentMigrator;

namespace ApiGestor.Infrastructure.Migrations.Versions;

[Migration((long)Enuns.EnumVersao.CriacaoTabelaUsuario, "Cria a tabela usuário")]
public class Version0000001 : Migration
{
    public override void Down() { }

    public override void Up()
    {
        var table = Create.Table("Usuario");
        VersionBase.InserirColunaPadrao(ref table);


        table.WithColumn("nome").AsString(100).NotNullable()
            .WithColumn("email").AsString(150).NotNullable()
            .WithColumn("senha").AsString(2000).NotNullable()
            .WithColumn("telefone").AsString(14).NotNullable();
    }
}
