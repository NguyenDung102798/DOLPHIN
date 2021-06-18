using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOLPHIN.Model
{
    public class CartItem
    {
        public Products Products { get; set; }
        public int Quantity { set; get; }
        public int Count { get; set; }
    }
}
