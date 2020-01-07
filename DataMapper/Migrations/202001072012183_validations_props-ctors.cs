namespace DataMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validations_propsctors : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Authors", "DateOfDeath", c => c.DateTime());
            AlterColumn("dbo.Editions", "Year", c => c.Int());
            AlterColumn("dbo.Borrowers", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Borrowers", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Editions", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "DateOfDeath", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
