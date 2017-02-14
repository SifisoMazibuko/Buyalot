namespace Buyalot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "confirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin", "confirmPassword");
        }
    }
}
