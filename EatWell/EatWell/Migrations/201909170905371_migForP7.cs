namespace EatWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migForP7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Menu_MenuId", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "Menu_MenuId" });
            DropColumn("dbo.Menus", "Menu_MenuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Menu_MenuId", c => c.Int());
            CreateIndex("dbo.Menus", "Menu_MenuId");
            AddForeignKey("dbo.Menus", "Menu_MenuId", "dbo.Menus", "MenuId");
        }
    }
}
