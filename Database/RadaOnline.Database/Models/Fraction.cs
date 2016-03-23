namespace RadaOnline.Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Fraction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public virtual ICollection<CouncilmanFraction> CouncilmanFractions { get; set; }

        public virtual Council Council { get; set; }
    }
}
