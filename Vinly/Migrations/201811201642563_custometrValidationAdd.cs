namespace Vinly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class custometrValidationAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime());
        }
    }
}
