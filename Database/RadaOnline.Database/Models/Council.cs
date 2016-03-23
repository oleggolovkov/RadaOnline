namespace RadaOnline.Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Council
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public int Size { get; set; }

        public virtual ICollection<Fraction> Fractions { get; set; }

        public virtual ICollection<Councilman> Councilmen { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
