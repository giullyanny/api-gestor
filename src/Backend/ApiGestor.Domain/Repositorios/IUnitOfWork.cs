namespace ApiGestor.Domain.Repositorios;

public interface IUnitOfWork
{
    Task Commit();
}
