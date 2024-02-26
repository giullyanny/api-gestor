using ApiGestor.Domain.Entidades;
using ApiGestor.Domain.Repositorio;
using ApiGestor.Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiGestor.Infrastructure.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly ContextoGestor _Contexto;

    public UsuarioRepositorio(ContextoGestor contexto)
    {
        _Contexto = contexto;
    }

    public async Task Adicionar(Usuario entidade) => await _Contexto.Usuario.AddAsync(entidade);

    public Task Atualizar(Usuario entidade)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Usuario>> Get(Func<Usuario, bool> filtro) => (Task<IEnumerable<Usuario>>)_Contexto.Usuario.AsQueryable().Where(filtro).AsEnumerable();

    public Task Remover(Usuario entidade)
    {
        throw new NotImplementedException();
    }

    public Task Remover(Guid id)
    {
        throw new NotImplementedException();
    }
}
