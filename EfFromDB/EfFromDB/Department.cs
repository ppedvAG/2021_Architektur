using System;
using System.Collections.Generic;

namespace EfFromDB
{
    public partial class Department
    {
        public Department()
        {
            Mitarbeiters = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; } = null!;

        public virtual ICollection<Employee> Mitarbeiters { get; set; }
    }
}
