namespace TeamNullGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentgame : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Student_StudentID" });
            AddColumn("dbo.Games", "studentID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "GameId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Student_StudentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Student_StudentID", c => c.Int());
            DropColumn("dbo.Students", "GameId");
            DropColumn("dbo.Games", "studentID");
            CreateIndex("dbo.Students", "Student_StudentID");
            AddForeignKey("dbo.Students", "Student_StudentID", "dbo.Students", "StudentID");
        }
    }
}
