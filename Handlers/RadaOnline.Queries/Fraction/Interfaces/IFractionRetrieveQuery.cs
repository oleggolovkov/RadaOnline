namespace RadaOnline.Queries.Fraction.Interfaces
{
    using RadaOnline.Queries.Fraction.Dto;

    public interface IFractionRetrieveQuery
    {
        FractionDetails Execute(int id);
    }
}
