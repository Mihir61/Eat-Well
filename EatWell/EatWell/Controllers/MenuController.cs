using EatWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatWell.Controllers
{
    public class MenuController : Controller
    {
        private readonly EatWellContext context = new EatWellContext();
        // GET: Menu
        public ActionResult Index()
        {

            List<Menu> menu = context.menus.ToList();
            return View(menu);
        }
        public ActionResult Add()
        {
            return View(new MenuModel());
        }
        [HttpPost]
        public ActionResult Add(MenuModel model)
        {
            var menu = new Menu()
            {
                Name = model.Name,
                Price = model.Price,
                Details = model.Details
            };
            context.menus.Add(menu);
            context.SaveChanges();
             
            foreach(var selectItem in model.SelectItems)
            {
                if (selectItem.IsSelect)
                {
                    var menuItem = new MenuItems()
                    {
                        MenuId = menu.MenuId,
                        ItemId = selectItem.ItemId,
                        Quantity = selectItem.Qty
                    };
                    context.menuItems.Add(menuItem);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
        public JsonResult GetMenuPriceById(int id)
        {
            var product = context.menus.Find(id);
            return Json(new { Price = product.Price,items = product.MenuItemCollection.Select(x=>x.FoodItem.Name) });
        }
    }
}