namespace ppedv.Personenverwaltung.Model.Contacts
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : Entity;
        T GetById<T>(int id) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;

        void Save();
    }

    public interface IRedLED
    {
    }

}
