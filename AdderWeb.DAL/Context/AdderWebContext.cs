namespace AdderWeb.DAL.Context;

public class AdderWebContext: DbContext
{
    public DbSet<Sum> Sums { get; set; }

    public AdderWebContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
