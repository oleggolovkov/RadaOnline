namespace RadaOnline.Queries.Councilman.Interfaces
{
    public interface ICouncilmanOverviewQuery
    {
        object Execute(int? councilId, int? fractionId, string name, int take, int skip);
    }
}
