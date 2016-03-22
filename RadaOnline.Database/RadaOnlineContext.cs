namespace RadaOnline.Database
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using RadaOnline.Database.Models;

    public class RadaOnlineContext : DbContext
    {

        public RadaOnlineContext() : base("RadaOnlineContext")
        {
        }

        public DbSet<Councilman> Councilmen { get; set; }

        public DbSet<Fraction> Fractions { get; set; }

        public DbSet<CouncilmanFraction> CouncilmanFractions { get; set; }

        public DbSet<Council> Councils { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionItem> SessionItems { get; set; }

        public DbSet<Decision> Decisions { get; set; }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
