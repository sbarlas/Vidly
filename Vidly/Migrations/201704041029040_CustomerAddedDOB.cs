namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAddedDOB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "DateOfBirth");
        }
    }
}
