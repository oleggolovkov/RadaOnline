namespace RadaOnline.Database.Repositories.Interfaces
{
    using System.Linq;

    using RadaOnline.Database.Models;

    public interface ICouncilRepository
    {
        IQueryable<Council> Overview(string name, int take, int skip);

        IQueryable<Council> Retrieve(int id);
    }
}
