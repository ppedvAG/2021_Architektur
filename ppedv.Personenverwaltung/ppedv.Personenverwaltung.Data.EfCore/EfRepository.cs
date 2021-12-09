using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;

namespace ppedv.Personenverwaltung.Data.EfCore
{
    public class EfRepository : IRepository
    {
        private EfContext _context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Kunde))
            //    _context.Kunden.Add(entity as Kunde);
            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update<T>(entity);
        }
    }
}
