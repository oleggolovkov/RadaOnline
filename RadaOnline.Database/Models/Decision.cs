namespace RadaOnline.Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RadaOnline.Database.Models.Enums;

    public class Decision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public DecitionType Type { get; set; }

        public bool IsAccepted { get; set; }

        [MaxLength(1024)]
        public string Url { get; set; }

        public virtual SessionItem SessionItem { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
