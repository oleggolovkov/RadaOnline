namespace RadaOnline.Queries.Council.Interfaces
{
    using System.Collections.Generic;

    using RadaOnline.Queries.Council.Dto;

    public interface ICouncilOverviewQuery
    {
        IList<CouncilListItem> Execute(string name, int take, int skip);
    }
}
