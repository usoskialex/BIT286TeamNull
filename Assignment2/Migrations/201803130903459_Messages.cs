namespace Assignment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        MessageText = c.String(nullable: false),
                        Receiver_UserID = c.Int(),
                        Sender_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Users", t => t.Receiver_UserID)
                .ForeignKey("dbo.Users", t => t.Sender_UserID)
                .Index(t => t.Receiver_UserID)
                .Index(t => t.Sender_UserID);
            
            AddColumn("dbo.Activities", "User_UserID", c => c.Int());
            CreateIndex("dbo.Activities", "User_UserID");
            CreateIndex("dbo.Users", "ProgramID");
            AddForeignKey("dbo.Activities", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Users", "ProgramID", "dbo.Programs", "ProgramID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Sender_UserID", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.Activities", "User_UserID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "ProgramID" });
            DropIndex("dbo.Messages", new[] { "Sender_UserID" });
            DropIndex("dbo.Messages", new[] { "Receiver_UserID" });
            DropIndex("dbo.Activities", new[] { "User_UserID" });
            DropColumn("dbo.Activities", "User_UserID");
            DropTable("dbo.Messages");
        }
    }
}
