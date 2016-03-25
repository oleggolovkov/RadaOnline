namespace RadaOnline.Queries.Session
{
    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Session.Dto;
    using RadaOnline.Queries.Session.Interfaces;
    using System.Linq;

    public class SessionRetrieveQuery : ISessionRetrieveQuery
    {
        private readonly ISessionRepository sessionRepository;

        public SessionRetrieveQuery(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public SessionDetails Execute(int id)
        {
            return
                this.sessionRepository.Retrieve(id)
                    .Select(
                        x =>
                        new SessionDetails
                            {
                                Id = x.Id,
                                Number = x.Number,
                                BeginDate = x.BeginDate,
                                EndDate = x.EndDate,
                                IsRegular = x.IsRegular
                            })
                    .FirstOrDefault();
        }
    }
}