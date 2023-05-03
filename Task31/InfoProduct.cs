using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class InfoProduct
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = null!;
        public string ImageProduct { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public decimal WeightProduct { get; set; }
        public decimal LengthProduct { get; set; }
        public decimal WidthProduct { get; set; }
        public decimal HeightProduct { get; set; }
        public int ProviderProduct { get; set; }

        public virtual ProviderProduct ProviderProductNavigation { get; set; } = null!;
        public virtual Cart? Cart { get; set; }
    }
}
