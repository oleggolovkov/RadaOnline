namespace RadaOnline.Queries.Council
{
    using System.Linq;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Council.Dto;
    using RadaOnline.Queries.Council.Interfaces;

    public class CouncilRetrieveQuery : ICouncilRetrieveQuery
    {
        private readonly ICouncilRepository councilRepository;

        public CouncilRetrieveQuery(ICouncilRepository councilRepository)
        {
            this.councilRepository = councilRepository;
        }

        public CouncilDetails Execute(int id)
        {
            return
                this.councilRepository.Retrieve(id)
                    .Select(x => new CouncilDetails { Id = x.Id, Name = x.Name, Size = x.Size })
                    .FirstOrDefault();
        }
    }
}
