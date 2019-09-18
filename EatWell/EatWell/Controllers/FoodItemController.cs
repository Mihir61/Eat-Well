using EatWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace EatWell.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly EatWellContext context = new EatWellContext();
        // GET: FoodItem
        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;
            IPagedList<FoodItem> foodItems = null;
            if (sortOrder == "Name")
            {
                if (sortOrder.Equals(CurrentSort))
                {
                    foodItems =context.foodItems.OrderByDescending
                            (m => m.Name).ToPagedList(pageIndex, pageSize);

                }
                else
                {
                    foodItems = context.foodItems.OrderBy
                            (m => m.Name).ToPagedList(pageIndex, pageSize);
                    ViewBag.CurrentSort = sortOrder;
                }
               
            }
                    
               
            return View(foodItems);
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
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FoodItem item = context.foodItems.SingleOrDefault(e => e.ItemId == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            FoodItem item = context.foodItems.SingleOrDefault(x => x.ItemId == id);
            context.foodItems.Remove(item ?? throw new InvalidOperationException());
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}