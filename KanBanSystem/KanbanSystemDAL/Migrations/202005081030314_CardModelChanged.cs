namespace KanbanSystemDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "CardName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "CardName");
        }
    }
}
