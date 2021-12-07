using System.Collections.Generic;

namespace HalloEFCore.Model
{
    class Abteilung
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public List<Mitarbeiter> Mitarbeiter { get; set; } = new List<Mitarbeiter>();
    }
}
