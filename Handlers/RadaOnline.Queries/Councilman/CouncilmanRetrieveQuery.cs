namespace RadaOnline.Queries.Councilman
{
    using System.Linq;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Councilman.Dto;
    using RadaOnline.Queries.Councilman.Interfaces;

    public class CouncilmanRetrieveQuery : ICouncilmanRetrieveQuery
    {
        private readonly ICouncilmanRepository councilmanRepository;

        public CouncilmanRetrieveQuery(ICouncilmanRepository councilmanRepository)
        {
            this.councilmanRepository = councilmanRepository;
        }

        public CouncilmanDetails Execute(int id)
        {
            return
                this.councilmanRepository.Retrieve(id)
                    .Select(
                        x =>
                        new CouncilmanDetails
                            {
                                Id = x.Id,
                                FullName = x.FullName,
                                ProfileImage = x.ProfileImage,
                                IsChairman = x.IsChairman
                            })
                    .FirstOrDefault();
        }
    }
}
