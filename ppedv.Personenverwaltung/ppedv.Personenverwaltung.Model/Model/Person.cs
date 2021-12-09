namespace ppedv.Personenverwaltung.Model
{
    public abstract class Person : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
    }
}