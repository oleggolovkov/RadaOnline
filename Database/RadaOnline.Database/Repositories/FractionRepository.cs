namespace RadaOnline.Database.Repositories
{
    using System.Linq;
    using RadaOnline.Database.Models;
    using RadaOnline.Database.Repositories.Interfaces;

    public class FractionRepository : IFractionRepository
    {
        private readonly IDbContext dbContext;

        public FractionRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Fraction> Overview(int? councilId, string name, int take, int skip)
        {
            var result = this.dbContext.Set<Fraction>().Select(x => x);

            if (councilId.HasValue)
            {
                result = result.Where(x => x.Council.Id == councilId.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.Name.Contains(name));
            }

            return result
                .OrderBy(x => x.Name)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Fraction> Retrieve(int id)
        {
            return this.dbContext.Set<Fraction>().Where(x => x.Id == id);
        }
    }
}
