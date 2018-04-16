using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesthoughtonWorldOfWicker.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ModelNumber { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public String ModelName { get; set; }
        public String productImageUrl { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }
        public String Description { get; set; }
        public List<Order> Orders { get; set; }
        public Category Category { get; set; }
    }
}