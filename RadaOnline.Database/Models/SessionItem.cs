namespace RadaOnline.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using RadaOnline.Database.Models.Enums;

    public class SessionItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public string Url { get; set; }

        public SessionItemStatus Status { get; set; }

        public virtual Session Session { get; set; }

        public virtual ICollection<Decision> Decisions { get; set; }
    }
}
