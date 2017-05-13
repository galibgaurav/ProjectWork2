namespace ProjectWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInfo", "state_ID", "dbo.State");
            DropIndex("dbo.ContactInfo", new[] { "state_ID" });
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScheduleTime = c.DateTime(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 32),
                        ContactInfoDetails_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContactInfo", t => t.ContactInfoDetails_ID)
                .Index(t => t.ContactInfoDetails_ID);
            
            AddColumn("dbo.State", "ContactInfoDetails_ID", c => c.Int());
            AlterColumn("dbo.State", "StateName", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.State", "ContactInfoDetails_ID");
            AddForeignKey("dbo.State", "ContactInfoDetails_ID", "dbo.ContactInfo", "ID");
            DropColumn("dbo.ContactInfo", "state_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactInfo", "state_ID", c => c.Int());
            DropForeignKey("dbo.State", "ContactInfoDetails_ID", "dbo.ContactInfo");
            DropForeignKey("dbo.Schedule", "ContactInfoDetails_ID", "dbo.ContactInfo");
            DropIndex("dbo.State", new[] { "ContactInfoDetails_ID" });
            DropIndex("dbo.Schedule", new[] { "ContactInfoDetails_ID" });
            AlterColumn("dbo.State", "StateName", c => c.String());
            DropColumn("dbo.State", "ContactInfoDetails_ID");
            DropTable("dbo.Schedule");
            CreateIndex("dbo.ContactInfo", "state_ID");
            AddForeignKey("dbo.ContactInfo", "state_ID", "dbo.State", "ID");
        }
    }
}
