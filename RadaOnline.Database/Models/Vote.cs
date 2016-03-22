namespace RadaOnline.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using RadaOnline.Database.Models.Enums;

    public class Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public VoteType Type { get; set; }

        public virtual Decision Decision { get; set; }

        public virtual Councilman Councilman { get; set; }
    }
}
