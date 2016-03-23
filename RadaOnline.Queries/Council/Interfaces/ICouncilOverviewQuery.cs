namespace RadaOnline.Queries.Council.Interfaces
{
    public interface ICouncilOverviewQuery
    {
        object Execute(string name, int take, int skip);
    }
}
