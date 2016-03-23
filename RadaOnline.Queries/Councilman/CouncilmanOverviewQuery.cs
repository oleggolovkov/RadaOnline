namespace RadaOnline.Queries.Councilman
{
    using RadaOnline.Queries.Councilman.Interfaces;

    public class CouncilmanOverviewQuery : ICouncilmanOverviewQuery
    {
        public object Execute(int? councilId, int? fractionId, string name, int take, int skip)
        {
            return "List of councilmen";
        }
    }
}
