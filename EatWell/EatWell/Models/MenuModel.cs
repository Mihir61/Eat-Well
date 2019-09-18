using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EatWell.Models
{
    [NotMapped]
    public class MenuModel:Menu
    {
        private EatWellContext _context;
        public List<SelectItem> SelectItems { get; set; }
        public List<FoodItem> FoodItems { get; set; }

        public MenuModel()
        {
            _context = new EatWellContext();
            FoodItems = _context.foodItems.ToList();
        }
    }
    [NotMapped]
    public class SelectItem
    {
        public int ItemId { get; set; }
        public bool IsSelect { get; set; }
        public int Qty { get; set; }
    }
}