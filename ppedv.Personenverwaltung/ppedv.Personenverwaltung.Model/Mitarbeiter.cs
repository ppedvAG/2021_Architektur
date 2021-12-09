namespace ppedv.Personenverwaltung.Model
{
    public class Mitarbeiter : Person
    {
        public string Beruf { get; set; }
        public ICollection<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
        public ICollection<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();
    }
}