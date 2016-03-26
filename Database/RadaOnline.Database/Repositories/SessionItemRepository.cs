namespace RadaOnline.Database.Repositories
{
    using System.Linq;

    using RadaOnline.Database.Models;
    using RadaOnline.Database.Repositories.Interfaces;

    public class SessionItemRepository : ISessionItemRepository
    {
        private readonly IDbContext dbContext;

        public SessionItemRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<SessionItem> Overview(int sessionId)
        {
            return this.dbContext.Set<SessionItem>().Where(x => x.Session.Id == sessionId);
        }

        public IQueryable<SessionItem> Retrieve(int id)
        {
            return this.dbContext.Set<SessionItem>().Where(x => x.Id == id);
        }
    }
}
