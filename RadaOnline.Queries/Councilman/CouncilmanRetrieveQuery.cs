namespace RadaOnline.Queries.Councilman
{
    using RadaOnline.Queries.Councilman.Interfaces;

    public class CouncilmanRetrieveQuery : ICouncilmanRetrieveQuery
    {
        public object Execute(int id)
        {
            return $"Councilman {id}";
        }
    }
}
