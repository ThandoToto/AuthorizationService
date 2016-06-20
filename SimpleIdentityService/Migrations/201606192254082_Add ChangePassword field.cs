namespace SimpleIdentityService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangePasswordfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ChangePassword", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ChangePassword");
        }
    }
}
