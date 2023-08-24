namespace AdderWeb.Domain.Contracts;

/// <summary>
/// Represents a unit of work for managing database transactions and repositories.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets a repository for the specified entity type.
    /// </summary>
    /// <typeparam name="T">The type of entity to retrieve a repository for.</typeparam>
    /// <returns>A repository for the specified entity type.</returns>
    public IRepository<T> GetRepository<T>() where T : class, IAggregateRoot;

    /// <summary>
    /// Saves any changes made to the underlying database asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous save operation.</returns>
    public Task CommitAsync();

    /// <summary>
    /// Saves any changes made to the underlying database.
    /// </summary>
    public void Commit();

    /// <summary>
    /// Begins a new database transaction.
    /// </summary>
    /// <returns>An instance of IDbContextTransaction representing the new transaction.</returns>
    public IDbContextTransaction BeginTransaction();
}
