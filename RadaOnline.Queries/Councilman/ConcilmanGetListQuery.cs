namespace RadaOnline.Queries.Councilman
{
    using RadaOnline.Queries.Councilman.Interfaces;

    public class ConcilmanGetListQuery : IConcilmanGetListQuery
    {
        public string Execute()
        {
            return "List of councilmen";
        }
    }
}
