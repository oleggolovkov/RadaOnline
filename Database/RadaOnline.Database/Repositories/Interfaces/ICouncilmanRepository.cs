namespace RadaOnline.Database.Repositories.Interfaces
{
    using System.Linq;

    using RadaOnline.Database.Models;

    public interface ICouncilmanRepository
    {
        IQueryable<Councilman> Overview(int? councilId, int? fractionId, string name, int take, int skip);

        IQueryable<Councilman> Retrieve(int id);
    }
}
