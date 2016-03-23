namespace RadaOnline.Database.Repositories
{
    using System.Linq;

    using RadaOnline.Database.Models;
    using RadaOnline.Database.Repositories.Interfaces;

    public class CouncilRepository : ICouncilRepository
    {
        private readonly IDbContext dbContext;

        public CouncilRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Council> Overview(string name, int take, int skip)
        {
            var result = this.dbContext.Set<Council>().Select(x => x);

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.Name.Contains(name));
            }

            return result
                .OrderBy(x => x.Name)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Council> Retrieve(int id)
        {
            return this.dbContext.Set<Council>().Where(x => x.Id == id);
        }
    }
}
