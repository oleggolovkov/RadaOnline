namespace RadaOnline.Queries.Council.Interfaces
{
    using RadaOnline.Queries.Council.Dto;

    public interface ICouncilRetrieveQuery
    {
        CouncilDetails Execute(int id);
    }
}
