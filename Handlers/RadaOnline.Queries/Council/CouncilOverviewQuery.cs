namespace RadaOnline.Queries.Council
{
    using System.Collections.Generic;
    using System.Linq;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Council.Dto;
    using RadaOnline.Queries.Council.Interfaces;

    public class CouncilOverviewQuery : ICouncilOverviewQuery
    {
        private readonly ICouncilRepository councilRepository;

        public CouncilOverviewQuery(ICouncilRepository councilRepository)
        {
            this.councilRepository = councilRepository;
        }

        public IList<CouncilItem> Execute(string name, int take, int skip)
        {
            return
                this.councilRepository.Overview(name, take, skip)
                    .Select(x => new CouncilItem { Id = x.Id, Name = x.Name })
                    .ToList();
        }
    }
}
