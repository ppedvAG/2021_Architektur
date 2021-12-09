using System;
using System.Collections.Generic;

namespace EfFromDB
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; } = null!;
        public int MitarbeiterId { get; set; }

        public virtual Person IdNavigation { get; set; } = null!;
        public virtual Employee Mitarbeiter { get; set; } = null!;
    }
}
