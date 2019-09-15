using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EatWell.Models
{
    
    public class WeeklyMenu
    {
        [Key]
        public int Id { get; set; }
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        public DayOfWeek DayName { get; set; }

        
    }
}