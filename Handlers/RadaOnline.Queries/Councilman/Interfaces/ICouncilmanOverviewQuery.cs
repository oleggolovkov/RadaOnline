namespace RadaOnline.Queries.Councilman.Interfaces
{
    using System.Collections.Generic;

    using RadaOnline.Queries.Councilman.Dto;

    public interface ICouncilmanOverviewQuery
    {
        IList<CouncilmanIListtem> Execute(int? councilId, int? fractionId, string name, int take, int skip);
    }
}
