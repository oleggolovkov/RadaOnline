namespace RadaOnline.Queries.Councilman
{
    using System.Collections.Generic;
    using System.Linq;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Councilman.Dto;
    using RadaOnline.Queries.Councilman.Interfaces;

    public class CouncilmanOverviewQuery : ICouncilmanOverviewQuery
    {
        private readonly ICouncilmanRepository councilmanRepository;

        public CouncilmanOverviewQuery(ICouncilmanRepository councilmanRepository)
        {
            this.councilmanRepository = councilmanRepository;
        }

        public IList<CouncilmanItem> Execute(int? councilId, int? fractionId, string name, int take, int skip)
        {
            return
                this.councilmanRepository.Overview(councilId, fractionId, name, take, skip)
                    .Select(
                        x =>
                        new CouncilmanItem
                            {
                                Id = x.Id,
                                FullName = x.FullName,
                                ProfileImage = x.ProfileImage,
                                IsChairman = x.IsChairman
                            })
                    .ToList();
        }
    }
}
