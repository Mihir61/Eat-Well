namespace EatWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "WeeklyMenu_Id", "dbo.WeeklyMenus");
            DropIndex("dbo.Menus", new[] { "WeeklyMenu_Id" });
            DropColumn("dbo.Menus", "WeeklyMenu_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "WeeklyMenu_Id", c => c.Int());
            CreateIndex("dbo.Menus", "WeeklyMenu_Id");
            AddForeignKey("dbo.Menus", "WeeklyMenu_Id", "dbo.WeeklyMenus", "Id");
        }
    }
}
