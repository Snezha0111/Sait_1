using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class Delivery
    {
        public int IdOrder { get; set; }
        public decimal SumWeightOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public decimal PriceDelivery { get; set; }

        public virtual Order1 IdOrderNavigation { get; set; } = null!;
    }
}
