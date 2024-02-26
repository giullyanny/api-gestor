using ApiGestor.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiGestor.Infrastructure.Contexto;

public class ContextoGestor : DbContext
{
    public ContextoGestor(DbContextOptions<ContextoGestor> options) : base(options) { }

    public DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoGestor).Assembly);
    }
}