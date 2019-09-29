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

            List<WeeklyMenu> weeklymenu = context.weeklyMenus.ToList();
            return View(weeklymenu);
        }
        public ActionResult Add()
        {
            return View(new WeeklyMenuModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(WeeklyMenuModel model)
        {

            foreach (var item in model.WeeklyMenuList)
            {

                var WeeklyMenuENtry = new WeeklyMenu()
                {
                    DayName = item.DayName,
                    MenuId = item.MenuId
                };

                
                context.weeklyMenus.Add(WeeklyMenuENtry);
                context.SaveChanges();
               
            }

            return RedirectToAction("Index");
        }

        public ActionResult Calender()
        {
           
            return View();
        }

        public ActionResult Table()
        {

            return View();
        }

        public JsonResult GetMenuByDate(string dt)
        {
            var date = Convert.ToDateTime(dt);
            var menus = context.weeklyMenus.Where(s => s.DayName == date.DayOfWeek);
            return Json(menus.Select(x=>new {menuName = x.Menu.Name,items=x.Menu.MenuItemCollection.Select(s=>s.FoodItem.Name) }));
        }

       
    }
}