using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using myPortal.Authentication.Application.Abstraction.Data;
using System.Threading.Tasks;

namespace myPortal.Authentication.Infrastructure.PortalDb;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyPortalDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(MyPortalDbContext context)
    {
        _context = context;
    }

    public IMyPortalDbContext Context => _context;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
            throw new InvalidOperationException("A transaction is already in progress.");

        // Use EF Core's execution strategy to handle transient failures
        var strategy = _context.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        });

    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null)
            throw new InvalidOperationException("No active transaction to commit.");

        try
        {
            await _context.SaveChangesAsync(cancellationToken);

            await _transaction.CommitAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // logging error
            await RollbackTransactionAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            await DisposeAsync();
        }
    }

    public async ValueTask DisposeTransaction()
    {
        if(_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task Dispose()
    {
        await DisposeTransaction();
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeTransaction();
        await _context.DisposeAsync();
    }

    public async Task<TResult> ExecuteInTransactionAsync<TResult>(Func<IMyPortalDbContext, CancellationToken, Task<TResult>> operation, CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var result = await operation(_context, cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return result;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if(_transaction is not null)
            await _transaction.RollbackAsync(cancellationToken);

        await DisposeAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
