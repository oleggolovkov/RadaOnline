namespace RadaOnline.Database.Repositories.Interfaces
{
    using System.Linq;

    using RadaOnline.Database.Models;

    public interface ISessionItemRepository
    {
        IQueryable<SessionItem> Overview(int sessionId);

        IQueryable<SessionItem> Retrieve(int id);
    }
}
