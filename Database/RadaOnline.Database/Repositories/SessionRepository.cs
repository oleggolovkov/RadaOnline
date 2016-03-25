namespace RadaOnline.Database.Repositories
{
    using RadaOnline.Database.Models;
    using RadaOnline.Database.Repositories.Interfaces;
    using System.Linq;

    public class SessionRepository : ISessionRepository
    {
        private readonly IDbContext dbContext;

        public SessionRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Session> Overview(int? councilId, int take, int skip)
        {
            var result = this.dbContext.Set<Session>().Select(x => x);

            if (councilId.HasValue)
            {
                result = result.Where(x => x.Council.Id == councilId.Value);
            }

            return result
                .OrderBy(x => x.BeginDate)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Session> Retrieve(int id)
        {
            return this.dbContext.Set<Session>().Where(x => x.Id == id);
        }
    }
}
