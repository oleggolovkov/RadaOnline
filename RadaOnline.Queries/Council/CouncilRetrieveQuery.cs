namespace RadaOnline.Queries.Council
{
    using RadaOnline.Queries.Council.Interfaces;
    public class CouncilRetrieveQuery : ICouncilRetrieveQuery
    {
        public object Execute(int id)
        {
            return $"Council {id}";
        }
    }
}
