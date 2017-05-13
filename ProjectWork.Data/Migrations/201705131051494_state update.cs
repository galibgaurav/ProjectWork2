namespace ProjectWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stateupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.State", "ContactInfoDetails_ID", "dbo.ContactInfo");
            DropIndex("dbo.State", new[] { "ContactInfoDetails_ID" });
            AlterColumn("dbo.State", "ContactInfoDetails_ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.State", "ContactInfoDetails_ID", c => c.Int());
            CreateIndex("dbo.State", "ContactInfoDetails_ID");
            AddForeignKey("dbo.State", "ContactInfoDetails_ID", "dbo.ContactInfo", "ID");
        }
    }
}
