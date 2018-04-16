using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WesthoughtonWorldOfWicker.Models;

namespace WesthoughtonWorldOfWicker.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
