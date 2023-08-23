namespace AdderWeb.Domain.Base;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}

public interface IBaseEntity<TKey>
{
    TKey Id { get; set; }
}