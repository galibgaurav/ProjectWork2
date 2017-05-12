namespace ProjectWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CallDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CallDuration = c.Time(nullable: false, precision: 7),
                        CallStatus = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CommunicationDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        communicationTypes = c.Short(nullable: false),
                        callDetails_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CallDetails", t => t.callDetails_ID)
                .Index(t => t.callDetails_ID);
            
            AddColumn("dbo.ContactHistory", "communicationTime", c => c.DateTime());
            AddColumn("dbo.ContactHistory", "userID", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.ContactHistory", "communicationDetails_ID", c => c.Int());
            CreateIndex("dbo.ContactHistory", "communicationDetails_ID");
            AddForeignKey("dbo.ContactHistory", "communicationDetails_ID", "dbo.CommunicationDetails", "ID");
            DropColumn("dbo.ContactHistory", "CallStatus");
            DropColumn("dbo.ContactHistory", "CallRemark");
            DropColumn("dbo.ContactHistory", "CallTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactHistory", "CallTime", c => c.DateTime());
            AddColumn("dbo.ContactHistory", "CallRemark", c => c.String(maxLength: 100));
            AddColumn("dbo.ContactHistory", "CallStatus", c => c.String(nullable: false));
            DropForeignKey("dbo.ContactHistory", "communicationDetails_ID", "dbo.CommunicationDetails");
            DropForeignKey("dbo.CommunicationDetails", "callDetails_ID", "dbo.CallDetails");
            DropIndex("dbo.ContactHistory", new[] { "communicationDetails_ID" });
            DropIndex("dbo.CommunicationDetails", new[] { "callDetails_ID" });
            DropColumn("dbo.ContactHistory", "communicationDetails_ID");
            DropColumn("dbo.ContactHistory", "userID");
            DropColumn("dbo.ContactHistory", "communicationTime");
            DropTable("dbo.CommunicationDetails");
            DropTable("dbo.CallDetails");
        }
    }
}
