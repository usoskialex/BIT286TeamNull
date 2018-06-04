namespace TeamNullGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "GameId", "dbo.Games");
            DropIndex("dbo.Students", new[] { "GameId" });
            CreateIndex("dbo.Games", "studentID");
            AddForeignKey("dbo.Games", "studentID", "dbo.Students", "StudentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "studentID", "dbo.Students");
            DropIndex("dbo.Games", new[] { "studentID" });
            CreateIndex("dbo.Students", "GameId");
            AddForeignKey("dbo.Students", "GameId", "dbo.Games", "GameId", cascadeDelete: true);
        }
    }
}
