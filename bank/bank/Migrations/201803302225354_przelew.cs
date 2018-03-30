namespace bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przelew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Przelews",
                c => new
                    {
                        Nadawca = c.String(nullable: false, maxLength: 128),
                        Odiorca = c.String(),
                        Stawka = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nadawca);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Przelews");
        }
    }
}
