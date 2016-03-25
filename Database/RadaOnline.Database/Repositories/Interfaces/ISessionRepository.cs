namespace RadaOnline.Database.Repositories.Interfaces
{
    using System.Linq;

    using RadaOnline.Database.Models;

    public interface ISessionRepository
    {
        IQueryable<Session> Overview(int? councilId, int take, int skip);

        IQueryable<Session> Retrieve(int id);
    }
}
