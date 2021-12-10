using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;

namespace ppedv.Personenverwaltung.Logik
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public IEnumerable<Kunde> GetKundenThatHaveBirtdayThatMonth(int month)
        {
            return Repository.GetAll<Kunde>().Where(x => x.GebDatum.Month == month);
        }

        public Mitarbeiter GetMitarbeiterWithMostKunden()
        {
            return Repository.GetAll<Mitarbeiter>().OrderBy(x => x.Kunden.Count()).FirstOrDefault();
        }
    }
}