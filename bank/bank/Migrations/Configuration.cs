namespace bank.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<bank.Models.LogInDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bank.Models.LogInDBContext context)
        {
            context.LogIns.AddOrUpdate(
           new Models.LogIn() { OId = Guid.NewGuid(), Login = "admin", Paswrd = "admin", Saldo = 10000000 }
           );
        }
    }
}
