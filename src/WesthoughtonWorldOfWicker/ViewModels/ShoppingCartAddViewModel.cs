using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WesthoughtonWorldOfWicker.ViewModels
{
    public class ShoppingCartAddViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int AddId { get; set; }
    }
}
