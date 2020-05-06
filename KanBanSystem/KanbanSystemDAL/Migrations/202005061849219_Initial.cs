namespace KanbanSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        BoardId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BoardId);
            
            CreateTable(
                "dbo.CardLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Board_BoardId = c.Int(),
                        Creator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Board_BoardId)
                .ForeignKey("dbo.Users", t => t.Creator_Id)
                .Index(t => t.Board_BoardId)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        CardList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CardLists", t => t.CardList_Id)
                .Index(t => t.CardList_Id);
            
            CreateTable(
                "dbo.CardActivities",
                c => new
                    {
                        CardActivityId = c.Int(nullable: false, identity: true),
                        CardActivityAction = c.String(),
                        Date = c.DateTime(nullable: false),
                        Card_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CardActivityId)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Card_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoginDatas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.LoginDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(nullable: false, maxLength: 500),
                        Card_Id = c.Int(),
                        CommentAuthor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .ForeignKey("dbo.Users", t => t.CommentAuthor_Id)
                .Index(t => t.Card_Id)
                .Index(t => t.CommentAuthor_Id);
            
            CreateTable(
                "dbo.LabelColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBoards",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Board_BoardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Board_BoardId })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Boards", t => t.Board_BoardId, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Board_BoardId);
            
            CreateTable(
                "dbo.UserCards",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Card_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.LabelColorCards",
                c => new
                    {
                        LabelColor_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LabelColor_Id, t.Card_Id })
                .ForeignKey("dbo.LabelColors", t => t.LabelColor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.LabelColor_Id)
                .Index(t => t.Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LabelColorCards", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.LabelColorCards", "LabelColor_Id", "dbo.LabelColors");
            DropForeignKey("dbo.Cards", "CardList_Id", "dbo.CardLists");
            DropForeignKey("dbo.Comments", "CommentAuthor_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Users", "Id", "dbo.LoginDatas");
            DropForeignKey("dbo.CardLists", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.UserCards", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.UserCards", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CardActivities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserBoards", "Board_BoardId", "dbo.Boards");
            DropForeignKey("dbo.UserBoards", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CardActivities", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.CardLists", "Board_BoardId", "dbo.Boards");
            DropIndex("dbo.LabelColorCards", new[] { "Card_Id" });
            DropIndex("dbo.LabelColorCards", new[] { "LabelColor_Id" });
            DropIndex("dbo.UserCards", new[] { "Card_Id" });
            DropIndex("dbo.UserCards", new[] { "User_Id" });
            DropIndex("dbo.UserBoards", new[] { "Board_BoardId" });
            DropIndex("dbo.UserBoards", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "CommentAuthor_Id" });
            DropIndex("dbo.Comments", new[] { "Card_Id" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.CardActivities", new[] { "User_Id" });
            DropIndex("dbo.CardActivities", new[] { "Card_Id" });
            DropIndex("dbo.Cards", new[] { "CardList_Id" });
            DropIndex("dbo.CardLists", new[] { "Creator_Id" });
            DropIndex("dbo.CardLists", new[] { "Board_BoardId" });
            DropTable("dbo.LabelColorCards");
            DropTable("dbo.UserCards");
            DropTable("dbo.UserBoards");
            DropTable("dbo.LabelColors");
            DropTable("dbo.Comments");
            DropTable("dbo.LoginDatas");
            DropTable("dbo.Users");
            DropTable("dbo.CardActivities");
            DropTable("dbo.Cards");
            DropTable("dbo.CardLists");
            DropTable("dbo.Boards");
        }
    }
}
