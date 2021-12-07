using System.Collections.Generic;

namespace HalloEFCore.Model
{
    class Mitarbeiter : Person
    {
        public string Job { get; set; }

        public List<Kunde> Kunden { get; set; } = new List<Kunde>();
        public List<Abteilung> Abteilungen { get; set; } = new List<Abteilung>();
    }
}
