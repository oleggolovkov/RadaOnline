namespace RadaOnline.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Session
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Number { get; set; }

        public bool IsRegular { get; set; }

        public virtual Council Council { get; set; }

        public virtual ICollection<SessionItem> SessionItems { get; set; } 
    }
}
