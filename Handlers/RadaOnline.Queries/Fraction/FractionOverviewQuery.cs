namespace RadaOnline.Queries.Fraction
{
    using RadaOnline.Queries.Fraction.Interfaces;

    public class FractionOverviewQuery: IFractionOverviewQuery
    {
        public object Execute(int councilId, string name, int take, int skip)
        {
            return "List of fractions";
        }
    }
}
