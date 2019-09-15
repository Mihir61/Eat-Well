using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EatWell.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [Required]
        [Display(Name ="Menu Name")]
        public string Name { get; set; }
        [Display(Name = "Menu Details")]
        public string Details { get; set; }
        [Required]
        public double Price { get; set; }
    }
}