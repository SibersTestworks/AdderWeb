using AdderWeb.DAL.Context;
using AdderWeb.Domain.Base;
using AdderWeb.Domain.Contracts;
using Ardalis.Specification.EntityFrameworkCore;

namespace AdderWeb.BLL;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : BaseEntity<Guid>, IAggregateRoot
{
    private readonly AdderWebContext dbContext;

    public EfRepository(AdderWebContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}