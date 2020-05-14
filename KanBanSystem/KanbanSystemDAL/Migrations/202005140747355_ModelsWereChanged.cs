namespace KanbanSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsWereChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CardLists", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Cards", "CardName", c => c.String());
            AlterColumn("dbo.Cards", "Description", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 30));
            AlterColumn("dbo.Comments", "CommentContent", c => c.String(maxLength: 500));
            AlterColumn("dbo.LabelColors", "Color", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LabelColors", "Color", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Comments", "CommentContent", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Cards", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Cards", "CardName", c => c.String(nullable: false));
            AlterColumn("dbo.CardLists", "Name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
