namespace ApiGestor.Domain.Entidades;

public class Usuario : Base
{
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
}
