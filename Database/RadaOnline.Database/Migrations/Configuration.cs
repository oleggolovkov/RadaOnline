namespace RadaOnline.Database.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RadaOnlineContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }
    }
}
