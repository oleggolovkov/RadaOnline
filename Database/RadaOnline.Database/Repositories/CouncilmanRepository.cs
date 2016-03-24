namespace RadaOnline.Database.Repositories
{
    using System.Linq;

    using RadaOnline.Database.Models;
    using RadaOnline.Database.Repositories.Interfaces;

    public class CouncilmanRepository : ICouncilmanRepository
    {
        private readonly IDbContext dbContext;

        public CouncilmanRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Councilman> Overview(int? councilId, int? fractionId, string name, int take, int skip)
        {
            var result = this.dbContext.Set<Councilman>().Select(x => x);

            if (councilId.HasValue)
            {
                result = result.Where(x => x.Council.Id == councilId.Value);
            }

            if (fractionId.HasValue)
            {
                result = result.Where(x => x.CouncilmanFractions.Any(f => f.Fraction.Id == fractionId.Value));
            }

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.FullName.Contains(name));
            }

            return result
                .OrderBy(x => x.FullName)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Councilman> Retrieve(int id)
        {
            return this.dbContext.Set<Councilman>().Where(x => x.Id == id);
        }
    }
}
