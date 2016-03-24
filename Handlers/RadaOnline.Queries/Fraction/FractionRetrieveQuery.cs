namespace RadaOnline.Queries.Fraction
{
    using System.Linq;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Fraction.Dto;
    using RadaOnline.Queries.Fraction.Interfaces;

    public class FractionRetrieveQuery: IFractionRetrieveQuery
    {
        private readonly IFractionRepository fractionRepository;

        public FractionRetrieveQuery(IFractionRepository fractionRepository)
        {
            this.fractionRepository = fractionRepository;
        }

        public FractionDetails Execute(int id)
        {
            return
                this.fractionRepository.Retrieve(id)
                    .Select(x => new FractionDetails { Id = x.Id, Name = x.Name })
                    .FirstOrDefault();
        }
    }
}
