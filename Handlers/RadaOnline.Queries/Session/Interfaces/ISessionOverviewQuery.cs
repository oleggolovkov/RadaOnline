namespace RadaOnline.Queries.Session.Interfaces
{
    using RadaOnline.Queries.Session.Dto;
    using System.Collections.Generic;

    public interface ISessionOverviewQuery
    {
        IList<SessionItem> Execute(int? councilId, int take, int skip); 
    }
}