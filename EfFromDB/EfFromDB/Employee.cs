using System;
using System.Collections.Generic;

namespace EfFromDB
{
    public partial class Employee
    {
        public Employee()
        {
            Customers = new HashSet<Customer>();
            Abteilungens = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Beruf { get; set; } = null!;

        public virtual Person IdNavigation { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Department> Abteilungens { get; set; }
    }
}
