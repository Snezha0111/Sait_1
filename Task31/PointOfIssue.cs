using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class PointOfIssue
    {
        public int IdPoint { get; set; }
        public string NamePoint { get; set; } = null!;
        public string AdresPoint { get; set; } = null!;
        public TimeSpan StartOfWork { get; set; }
        public TimeSpan EndOfWork { get; set; }
    }
}
