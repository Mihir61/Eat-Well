using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EatWell.Models
{
    public class FoodItem
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [Display(Name ="Food Name")]
        public string Name { get; set; }
    }
}