using EatWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatWell.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly EatWellContext context = new EatWellContext();
        // GET: FoodItem
        public ActionResult Index()
        {
            return View(context.foodItems.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FoodItem foodItem)
        {
           
            
                context.foodItems.Add(foodItem);
                context.SaveChanges();
            
            return View(foodItem);
        }
    }
}