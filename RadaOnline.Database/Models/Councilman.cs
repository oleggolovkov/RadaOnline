namespace RadaOnline.Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Councilman
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string FullName { get; set; }

        [MaxLength(1024)]
        public string ProfileImage { get; set; }

        public bool IsChairman { get; set; }

        public virtual ICollection<CouncilmanFraction> CouncilmanFractions { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual Council Council { get; set; }
    }
}
