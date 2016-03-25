namespace RadaOnline.Queries.Session.Dto
{
    using System;

    public class SessionDetails
    {
        public int Id { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Number { get; set; }

        public bool IsRegular { get; set; }
    }
}
