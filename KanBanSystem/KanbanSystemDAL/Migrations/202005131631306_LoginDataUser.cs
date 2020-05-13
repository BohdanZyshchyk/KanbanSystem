namespace KanbanSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginDataUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.LoginDatas");
            DropForeignKey("dbo.UserBoards", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CardActivities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCards", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CardLists", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "CommentAuthor_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            RenameColumn(table: "dbo.UserBoards", name: "User_Id", newName: "User_UserId");
            RenameColumn(table: "dbo.CardLists", name: "Creator_Id", newName: "Creator_UserId");
            RenameColumn(table: "dbo.UserCards", name: "User_Id", newName: "User_UserId");
            RenameColumn(table: "dbo.CardActivities", name: "User_Id", newName: "User_UserId");
            RenameColumn(table: "dbo.Comments", name: "CommentAuthor_Id", newName: "CommentAuthor_UserId");
            RenameIndex(table: "dbo.CardLists", name: "IX_Creator_Id", newName: "IX_Creator_UserId");
            RenameIndex(table: "dbo.CardActivities", name: "IX_User_Id", newName: "IX_User_UserId");
            RenameIndex(table: "dbo.Comments", name: "IX_CommentAuthor_Id", newName: "IX_CommentAuthor_UserId");
            RenameIndex(table: "dbo.UserBoards", name: "IX_User_Id", newName: "IX_User_UserId");
            RenameIndex(table: "dbo.UserCards", name: "IX_User_Id", newName: "IX_User_UserId");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 30));
            AddPrimaryKey("dbo.Users", "UserId");
            AddForeignKey("dbo.UserBoards", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.CardActivities", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserCards", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.CardLists", "Creator_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Comments", "CommentAuthor_UserId", "dbo.Users", "UserId");
            DropColumn("dbo.Users", "Id");
            DropColumn("dbo.Users", "Name");
            DropTable("dbo.LoginDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoginDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "CommentAuthor_UserId", "dbo.Users");
            DropForeignKey("dbo.CardLists", "Creator_UserId", "dbo.Users");
            DropForeignKey("dbo.UserCards", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.CardActivities", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UserBoards", "User_UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "UserId");
            AddPrimaryKey("dbo.Users", "Id");
            RenameIndex(table: "dbo.UserCards", name: "IX_User_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.UserBoards", name: "IX_User_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_CommentAuthor_UserId", newName: "IX_CommentAuthor_Id");
            RenameIndex(table: "dbo.CardActivities", name: "IX_User_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.CardLists", name: "IX_Creator_UserId", newName: "IX_Creator_Id");
            RenameColumn(table: "dbo.Comments", name: "CommentAuthor_UserId", newName: "CommentAuthor_Id");
            RenameColumn(table: "dbo.CardActivities", name: "User_UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserCards", name: "User_UserId", newName: "User_Id");
            RenameColumn(table: "dbo.CardLists", name: "Creator_UserId", newName: "Creator_Id");
            RenameColumn(table: "dbo.UserBoards", name: "User_UserId", newName: "User_Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Comments", "CommentAuthor_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.CardLists", "Creator_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserCards", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CardActivities", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserBoards", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.LoginDatas", "Id");
        }
    }
}
