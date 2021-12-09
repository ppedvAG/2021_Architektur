namespace ppedv.Personenverwaltung.Model
{
    public class Kunde : Person
    {
        public string KdNummer { get; set; }
        public virtual Mitarbeiter Mitarbeiter { get; set; }
    }
}