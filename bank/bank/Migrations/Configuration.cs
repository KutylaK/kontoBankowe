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
           new Models.LogIn() { OId = Guid.NewGuid(), Login = "admin", Paswrd = "admin", Saldo = 10000000 },
           new Models.LogIn() { OId = Guid.NewGuid(), Login = "seba", Paswrd = "seba", Saldo = 100 },
           new Models.LogIn() { OId = Guid.NewGuid(), Login = "michal", Paswrd = "michal", Saldo = 100 },
           new Models.LogIn() { OId = Guid.NewGuid(), Login = "piotrek", Paswrd = "piotrek", Saldo = 100 }
           );
        }

        public static void Updating(bank.Models.LogInDBContext context)
        {
            Configuration conf = new Configuration();
            conf.Seed(context);
        }
    }
}
