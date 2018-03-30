namespace bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogIns", "Saldo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogIns", "Saldo");
        }
    }
}
