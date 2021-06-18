using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.Model
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
