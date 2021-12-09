using System;
using System.Collections.Generic;

namespace EfFromDB
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime GebDatum { get; set; }
        public bool? Werkljnwekljfn { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
}
