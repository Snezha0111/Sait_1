using System;
using System.Collections.Generic;

namespace Task31
{
    public partial class Recipient
    {
        public Recipient()
        {
            Order1s = new HashSet<Order1>();
        }

        public int IdRec { get; set; }
        public string LoginRec { get; set; } = null!;
        public string PasswordRec { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? EmailRes { get; set; }
        public string Surname { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Order1> Order1s { get; set; }
    }
}
