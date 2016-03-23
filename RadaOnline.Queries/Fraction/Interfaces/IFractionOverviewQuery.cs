namespace RadaOnline.Queries.Fraction.Interfaces
{
    public interface IFractionOverviewQuery
    {
        object Execute(int councilId, string name, int take, int skip);
    }
}
