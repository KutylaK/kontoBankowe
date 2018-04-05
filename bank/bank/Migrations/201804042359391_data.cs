namespace bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Przelews", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Przelews", "Data");
        }
    }
}
