namespace RadaOnline.Database.Repositories.Interfaces
{
    using System.Linq;

    using RadaOnline.Database.Models;

    public interface IFractionRepository
    {
        IQueryable<Fraction> Overview(int? councilId, string name, int take, int skip);

        IQueryable<Fraction> Retrieve(int id);
    }
}
