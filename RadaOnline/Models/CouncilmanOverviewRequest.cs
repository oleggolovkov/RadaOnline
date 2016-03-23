namespace RadaOnline.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CouncilmanOverviewRequest
    {
        [Required(ErrorMessage = "CouncilId is required")]
        public int? CouncilId { get; set; }

        public int? FractionId { get; set; }

        public string Name { get; set; }

        public int? Take { get; set; }

        public int? Skip { get; set; }
    }
}