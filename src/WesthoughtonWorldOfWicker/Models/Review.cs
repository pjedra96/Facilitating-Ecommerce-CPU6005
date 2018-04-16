using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesthoughtonWorldOfWicker.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int OrderId { get; set; }
        public String Email { get; set; }
        public int Rating { get; set; }
        public String Comments { get; set; }
        public Product Product { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
