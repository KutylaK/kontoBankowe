namespace bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogIns",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Paswrd = c.String(),
                    })
                .PrimaryKey(t => t.Login);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogIns");
        }
    }
}
