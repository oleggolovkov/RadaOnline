namespace RadaOnline.Queries.Council
{
    using RadaOnline.Queries.Council.Interfaces;
    public class CouncilOverviewQuery : ICouncilOverviewQuery
    {
        public object Execute(string name, int take, int skip)
        {
            return "List of councils";
        }
    }
}
