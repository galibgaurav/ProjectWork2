namespace ProjectWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedule", "ContactInfoDetails_ID", "dbo.ContactInfo");
            DropIndex("dbo.Schedule", new[] { "ContactInfoDetails_ID" });
            AddColumn("dbo.Schedule", "ContactInfoDetails_ID1", c => c.Int());
            AlterColumn("dbo.Schedule", "ContactInfoDetails_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedule", "ContactInfoDetails_ID1");
            AddForeignKey("dbo.Schedule", "ContactInfoDetails_ID1", "dbo.ContactInfo", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "ContactInfoDetails_ID1", "dbo.ContactInfo");
            DropIndex("dbo.Schedule", new[] { "ContactInfoDetails_ID1" });
            AlterColumn("dbo.Schedule", "ContactInfoDetails_ID", c => c.Int());
            DropColumn("dbo.Schedule", "ContactInfoDetails_ID1");
            CreateIndex("dbo.Schedule", "ContactInfoDetails_ID");
            AddForeignKey("dbo.Schedule", "ContactInfoDetails_ID", "dbo.ContactInfo", "ID");
        }
    }
}
