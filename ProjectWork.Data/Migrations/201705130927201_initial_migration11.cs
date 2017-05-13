namespace ProjectWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedule", "ContactInfoDetails_ID1", "dbo.ContactInfo");
            DropIndex("dbo.Schedule", new[] { "ContactInfoDetails_ID1" });
            DropColumn("dbo.Schedule", "ContactInfoDetails_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedule", "ContactInfoDetails_ID1", c => c.Int());
            CreateIndex("dbo.Schedule", "ContactInfoDetails_ID1");
            AddForeignKey("dbo.Schedule", "ContactInfoDetails_ID1", "dbo.ContactInfo", "ID");
        }
    }
}
