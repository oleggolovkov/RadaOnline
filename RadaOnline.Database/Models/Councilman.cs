namespace RadaOnline.Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Councilman
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<CouncilmanFraction> CouncilmanFractions { get; set; }
    }
}
