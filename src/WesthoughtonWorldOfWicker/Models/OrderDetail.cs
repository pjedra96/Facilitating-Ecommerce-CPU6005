using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesthoughtonWorldOfWicker.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
