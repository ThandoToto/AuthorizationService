namespace SimpleIdentityService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Readdingfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ChangePassword", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ChangePassword");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
