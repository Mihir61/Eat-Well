using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EatWell.Models
{
    public class EatWellContext : DbContext
    {
        public  EatWellContext() : base("DbConString")
        {
           
        }

       public DbSet<FoodItem> foodItems { get; set; }
       public DbSet<Menu> menus { get; set; }
       public DbSet<MenuItems> menuItems { get; set; }
       public DbSet<WeeklyMenu> weeklyMenus { get; set; }


    }       
}