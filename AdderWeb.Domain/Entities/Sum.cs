using AdderWeb.Domain.Base;
using AdderWeb.Domain.Contracts;


namespace AdderWeb.Domain.Entities;

public class Sum : BaseEntity<Guid>, IAggregateRoot
{
    public double First { get; set; }
    public double Second { get; set; }
    public double Result { get; set; }
}
