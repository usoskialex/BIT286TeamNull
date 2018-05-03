namespace Assignment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Guess = c.Int(nullable: false),
                        TotalCorrect = c.Int(nullable: false),
                        TotalIncorrect = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Number2 = c.Int(nullable: false),
                        Number3 = c.Int(nullable: false),
                        Number4 = c.Int(nullable: false),
                        Answer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
