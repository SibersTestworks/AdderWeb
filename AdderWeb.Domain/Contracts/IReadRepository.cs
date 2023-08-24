namespace AdderWeb.Domain.Contracts;

/// <inheritdoc />
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
