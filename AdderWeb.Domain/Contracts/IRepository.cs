namespace AdderWeb.Domain.Contracts;

/// <inheritdoc />
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
