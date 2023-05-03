using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class ProviderProduct
    {
        public ProviderProduct()
        {
            InfoProducts = new HashSet<InfoProduct>();
        }

        public int IdProvider { get; set; }
        public string NameProvider { get; set; } = null!;
        public string? Email { get; set; }
        public string Phone { get; set; } = null!;
        public string Adres { get; set; } = null!;

        public virtual ICollection<InfoProduct> InfoProducts { get; set; }
    }
}
