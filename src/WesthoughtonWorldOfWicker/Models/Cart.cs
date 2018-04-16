using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesthoughtonWorldOfWicker.Models
{
    public class Cart
    {
        [Key]
        public int CartItemId { get; set; }
        [Required]
        public String CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
        public virtual Product Product { get; set; }
    }
}
