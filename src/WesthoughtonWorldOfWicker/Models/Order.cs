using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesthoughtonWorldOfWicker.Models
{
    public class Order
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public int InfoId { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public String Username { get; set; }
        [ScaffoldColumn(false)]
        [CreditCard]
        public String CardNumber { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Product Product { get; set; }
        public Info Info { get; set; }
    }
}
