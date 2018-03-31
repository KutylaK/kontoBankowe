namespace bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bez_uint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogIns",
                c => new
                    {
                        OId = c.Guid(nullable: false),
                        Login = c.String(maxLength: 30),
                        Paswrd = c.String(),
                        Saldo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OId)
                .Index(t => t.Login, unique: true);
            
            CreateTable(
                "dbo.Przelews",
                c => new
                    {
                        OId = c.Guid(nullable: false),
                        Nadawca = c.String(),
                        Odbiorca = c.String(),
                        Stawka = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LogIns", new[] { "Login" });
            DropTable("dbo.Przelews");
            DropTable("dbo.LogIns");
        }
    }
}
