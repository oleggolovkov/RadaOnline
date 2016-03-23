namespace RadaOnline.Queries.Fraction
{
    using RadaOnline.Queries.Fraction.Interfaces;

    public class FractionRetrieveQuery: IFractionRetrieveQuery
    {
        public object Execute(int id)
        {
            return $"Fraction {id}";
        }
    }
}
