namespace EatWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migForP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Menu_MenuId", c => c.Int());
            CreateIndex("dbo.Menus", "Menu_MenuId");
            AddForeignKey("dbo.Menus", "Menu_MenuId", "dbo.Menus", "MenuId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Menu_MenuId", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "Menu_MenuId" });
            DropColumn("dbo.Menus", "Menu_MenuId");
        }
    }
}
