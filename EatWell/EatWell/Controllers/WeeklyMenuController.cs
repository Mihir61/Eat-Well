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
        
        public JsonResult GetMenuByDate(string dt)
        {
            var date = Convert.ToDateTime(dt);
            var menu = context.weeklyMenus.FirstOrDefault(s => s.DayName == date.DayOfWeek);
            return Json(new { menuName = menu.Menu.Name, items =menu.Menu.MenuItemCollection.Select(x=>x.FoodItem.Name) });
        }

       
    }
}