namespace RadaOnline.Queries.Fraction.Interfaces
{
    using System.Collections.Generic;

    using RadaOnline.Queries.Fraction.Dto;

    public interface IFractionOverviewQuery
    {
        IList<FractionItem> Execute(int? councilId, string name, int take, int skip);
    }
}
