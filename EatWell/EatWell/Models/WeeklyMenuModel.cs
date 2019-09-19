using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EatWell.Models
{
    [NotMapped]
    public class WeeklyMenuModel
    {
        public List<WeeklyMenu> WeeklyMenuList { get; set; }
        public List<Menu> Menus { get; set; }
        private EatWellContext _context;

        public WeeklyMenuModel()
        {
            _context = new EatWellContext();
            Menus = _context.menus.ToList();
        }
    }
}