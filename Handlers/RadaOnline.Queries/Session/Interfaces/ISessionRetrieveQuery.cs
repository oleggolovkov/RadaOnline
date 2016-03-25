namespace RadaOnline.Queries.Session.Interfaces
{
    using RadaOnline.Queries.Session.Dto;

    public interface ISessionRetrieveQuery
    {
        SessionDetails Execute(int id);
    }
}