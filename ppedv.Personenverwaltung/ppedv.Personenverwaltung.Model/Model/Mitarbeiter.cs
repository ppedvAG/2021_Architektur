namespace ppedv.Personenverwaltung.Model
{
    public class Mitarbeiter : Person
    {
        public string Beruf { get; set; }
        public virtual ICollection<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
        public virtual ICollection<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();
    }
}