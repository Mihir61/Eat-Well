namespace EatWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "WeeklyMenu_Id", c => c.Int());
            CreateIndex("dbo.Menus", "WeeklyMenu_Id");
            AddForeignKey("dbo.Menus", "WeeklyMenu_Id", "dbo.WeeklyMenus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "WeeklyMenu_Id", "dbo.WeeklyMenus");
            DropIndex("dbo.Menus", new[] { "WeeklyMenu_Id" });
            DropColumn("dbo.Menus", "WeeklyMenu_Id");
        }
    }
}
