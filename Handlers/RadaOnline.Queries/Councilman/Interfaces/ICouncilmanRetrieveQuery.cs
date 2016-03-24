namespace RadaOnline.Queries.Councilman.Interfaces
{
    using RadaOnline.Queries.Councilman.Dto;

    public interface ICouncilmanRetrieveQuery
    {
        CouncilmanDetails Execute(int id);
    }
}
