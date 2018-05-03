namespace Assignment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gameviewmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Guess");
            DropColumn("dbo.Games", "Number");
            DropColumn("dbo.Games", "Number2");
            DropColumn("dbo.Games", "Number3");
            DropColumn("dbo.Games", "Number4");
            DropColumn("dbo.Games", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Answer", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Number4", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Number3", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Number2", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Guess", c => c.Int(nullable: false));
        }
    }
}
