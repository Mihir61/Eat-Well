using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EatWell.Models
{
    public class MenuItems
    {
        [Key]
        public int Id { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu menu { get; set; } 

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual FoodItem FoodItem { get; set; } 

        public int Quantity { get; set; }
       
      
    }
}