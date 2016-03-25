namespace RadaOnline.Queries.Session
{
    using System.Collections.Generic;
    using System.Linq;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Session.Dto;
    using RadaOnline.Queries.Session.Interfaces;

    public class SessionOverviewQuery : ISessionOverviewQuery
    {
        private readonly ISessionRepository sessionRepository;

        public SessionOverviewQuery(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public IList<SessionItem> Execute(int? councilId, int take, int skip)
        {
            return this.sessionRepository.Overview(councilId, take, skip)
                .Select(x => new SessionItem { Id = x.Id, Number = x.Number, BeginDate = x.BeginDate })
                .ToList();
        }
    }
}