namespace Assignment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class game : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Programs", "ChoseProgram_ProgramID", "dbo.Programs");
            DropForeignKey("dbo.Programs", "User_UserID", "dbo.Users");
            DropIndex("dbo.Programs", new[] { "ChoseProgram_ProgramID" });
            DropIndex("dbo.Programs", new[] { "User_UserID" });
            AddColumn("dbo.Activities", "User_UserID", c => c.Int());
            CreateIndex("dbo.Activities", "User_UserID");
            AddForeignKey("dbo.Activities", "User_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.Users", "ProgramID");
            DropTable("dbo.Programs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramID = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                        ChoseProgram_ProgramID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ProgramID);
            
            AddColumn("dbo.Users", "ProgramID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Activities", "User_UserID", "dbo.Users");
            DropIndex("dbo.Activities", new[] { "User_UserID" });
            DropColumn("dbo.Activities", "User_UserID");
            CreateIndex("dbo.Programs", "User_UserID");
            CreateIndex("dbo.Programs", "ChoseProgram_ProgramID");
            AddForeignKey("dbo.Programs", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Programs", "ChoseProgram_ProgramID", "dbo.Programs", "ProgramID");
        }
    }
}
