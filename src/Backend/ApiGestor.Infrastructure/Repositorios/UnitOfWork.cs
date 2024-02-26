using ApiGestor.Domain.Repositorios;
using ApiGestor.Infrastructure.Contexto;
using Microsoft.Identity.Client.Extensibility;

namespace ApiGestor.Infrastructure.Repositorios;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private ContextoGestor _contexto;
    private bool _disposed;

    public UnitOfWork(ContextoGestor contexto)
    {
        _contexto = contexto;
    }

    public async Task Commit()
    {
        await _contexto.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _contexto.Dispose();
        }

        _disposed = true;
    }
}
