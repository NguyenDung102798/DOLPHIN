using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.Model
{
    public class Options
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public string  Color { get; set; }

        public virtual ICollection<ProductOption> ProductOptions { get; set; }

    }
}
