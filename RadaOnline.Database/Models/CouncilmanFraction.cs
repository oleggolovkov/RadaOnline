namespace RadaOnline.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CouncilmanFraction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Councilman Councilman { get; set; }

        public Fraction Fraction { get; set; }

        public DateTime? ValidUntil { get; set; }
    }
}
