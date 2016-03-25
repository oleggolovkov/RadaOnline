namespace RadaOnline.Models
{
    public class CouncilmanOverviewRequest
    {
        public int? FractionId { get; set; }

        public string Name { get; set; }

        public int? Take { get; set; }

        public int? Skip { get; set; }
    }
}