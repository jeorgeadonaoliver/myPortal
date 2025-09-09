namespace myPortal.Authentication.Application.Abstraction.Data;

public interface IUnitOfWork: IDisposable, IAsyncDisposable
{
    IMyPortalDbContext Context { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
