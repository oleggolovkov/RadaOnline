namespace RadaOnline.Queries.Fraction
{
    using System.Collections.Generic;
    using System.Linq;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Fraction.Dto;
    using RadaOnline.Queries.Fraction.Interfaces;

    public class FractionOverviewQuery: IFractionOverviewQuery
    {
        private readonly IFractionRepository fractionRepository;

        public FractionOverviewQuery(IFractionRepository fractionRepository)
        {
            this.fractionRepository = fractionRepository;
        }

        public IList<FractionItem> Execute(int? councilId, string name, int take, int skip)
        {
            return
                this.fractionRepository.Overview(councilId, name, take, skip)
                    .Select(x => new FractionItem { Id = x.Id, Name = x.Name })
                    .ToList();
        }
    }
}
