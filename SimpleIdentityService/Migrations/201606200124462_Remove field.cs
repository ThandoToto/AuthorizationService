namespace SimpleIdentityService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removefield : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ChangePassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ChangePassword", c => c.Boolean());
        }
    }
}
