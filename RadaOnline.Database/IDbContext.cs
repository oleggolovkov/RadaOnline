namespace RadaOnline.Database
{
    using System.Data.Entity;

    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
