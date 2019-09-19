using EatWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatWell.Controllers
{
    public class WeeklyMenuController : Controller
    {
        private readonly EatWellContext context = new EatWellContext();
        // GET: WeeklyMenu
        public ActionResult Index()
        {
            var days = DateTime.DaysInMonth(2019,09);
            List<WeeklyMenu> weeklymenu = context.weeklyMenus.ToList();
            return View(weeklymenu);
        }
        public ActionResult Add()
        {
            return View(new WeeklyMenuModel());
        }
        [HttpPost]
        public ActionResult Add(WeeklyMenu weeklyMenu)
        {
            //////var day = DateTime.DaysInMonth(2019, 09);
            
            var weeklymenu = new WeeklyMenu
            {
                DayName = weeklyMenu.DayName,
                MenuId = weeklyMenu.MenuId,

            };

            context.weeklyMenus.Add(weeklyMenu);
            context.SaveChanges();


            return View(weeklyMenu);
        }
    }
}