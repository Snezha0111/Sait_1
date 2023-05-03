using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class Cart
    {
        public int IdProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int CountProduct { get; set; }

        public virtual InfoProduct IdProductNavigation { get; set; } = null!;
    }
}
