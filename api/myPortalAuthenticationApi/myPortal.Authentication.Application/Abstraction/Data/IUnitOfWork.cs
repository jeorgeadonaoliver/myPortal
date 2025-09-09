using Microsoft.EntityFrameworkCore;

namespace myPortal.Authentication.Application.Abstraction.Data;

public interface IUnitOfWork: IDisposable, IAsyncDisposable
{
    IMyPortalDbContext Context { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    Task<TResult> ExecuteInTransactionAsync<TResult>(
       Func<IMyPortalDbContext, CancellationToken, Task<TResult>> operation,
       CancellationToken cancellationToken = default);

}
