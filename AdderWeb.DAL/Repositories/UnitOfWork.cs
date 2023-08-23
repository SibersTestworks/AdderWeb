namespace AdderWeb.DAL.Repositories;

/// <inheritdoc cref="IUnitOfWork"/>
public class AdderWebUnitOfWork : IUnitOfWork
{
    private readonly AdderWebContext dbContext;
    private readonly IServiceProvider serviceProvider;

    public AdderWebUnitOfWork(AdderWebContext dbContext, IServiceProvider serviceProvider)
    {
        this.dbContext = dbContext;
        this.serviceProvider = serviceProvider;
    }

    public IRepository<T> GetRepository<T>() where T : class, IAggregateRoot
    {
        return serviceProvider.GetRequiredService<IRepository<T>>();
    }

    public async Task CommitAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public void Commit()
    {
        dbContext.SaveChanges();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return dbContext.Database.BeginTransaction();
    }
}

