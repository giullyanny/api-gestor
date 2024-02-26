using ApiGestor.Domain.Entidades;

namespace ApiGestor.Domain.Repositorio;

public interface IRepositorioBase<T> where T : class
{
    Task Adicionar(T entidade);
    Task Remover(T entidade);
    Task Remover(Guid id);
    Task Atualizar(T entidade);
}
