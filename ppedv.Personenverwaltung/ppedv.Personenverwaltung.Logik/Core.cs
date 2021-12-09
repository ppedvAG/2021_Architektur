using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;

namespace ppedv.Personenverwaltung.Logik
{
    public class Core
    {
        private IRepository repo = new Data.EfCore.EfRepository();



        public IEnumerable<Kunde> GetKundenThatHaveBirtdayThatMonth(int month)
        {
            return repo.GetAll<Kunde>().Where(x => x.GebDatum.Month == month);
        }

    }
}