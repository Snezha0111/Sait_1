using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class OrderRazb
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }

        public virtual Order1 IdOrderNavigation { get; set; } = null!;
        public virtual Cart IdProductNavigation { get; set; } = null!;
    }
}
