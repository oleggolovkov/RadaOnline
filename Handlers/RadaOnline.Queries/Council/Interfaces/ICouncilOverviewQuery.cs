namespace RadaOnline.Queries.Council.Interfaces
{
    using System.Collections.Generic;

    using RadaOnline.Queries.Council.Dto;

    public interface ICouncilOverviewQuery
    {
        IList<CouncilItem> Execute(string name, int take, int skip);
    }
}
