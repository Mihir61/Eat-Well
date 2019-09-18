using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatWell.Controllers
{
    public class WeeklyMenuController : Controller
    {
        // GET: WeeklyMenu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}