using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;

namespace ppedv.Personenverwaltung.Logik
{
    public class Core
    {
        public IRepository Repository { get; } = new Data.EfCore.EfRepository();

        public IEnumerable<Kunde> GetKundenThatHaveBirtdayThatMonth(int month)
        {
            return Repository.GetAll<Kunde>().Where(x => x.GebDatum.Month == month);
        }
    }
}