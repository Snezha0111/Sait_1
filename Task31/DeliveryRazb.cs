using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class DeliveryRazb
    {
        public int IdOrder { get; set; }
        public int IdPoint { get; set; }

        public virtual Delivery IdOrderNavigation { get; set; } = null!;
        public virtual PointOfIssue IdPointNavigation { get; set; } = null!;
    }
}
