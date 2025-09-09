using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.PortalDb;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyPortalDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(MyPortalDbContext context)
    {
        _context = context;
    }

    public IMyPortalDbContext Context => _context;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            await _transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.RollbackAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
