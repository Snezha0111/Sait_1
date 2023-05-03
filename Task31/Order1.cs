using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class Order1
    {
        public int IdOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public string StatusOrder { get; set; } = null!;
        public decimal PriceOrder { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string MethodOfObtaining { get; set; } = null!;
        public int IdRec { get; set; }
        public string NamePointOfIssue { get; set; } = null!;

        public virtual Recipient IdRecNavigation { get; set; } = null!;
        public virtual Delivery? Delivery { get; set; }
    }
}
