using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Personenverwaltung.Logik.Tests
{
    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Mitarbeiter))
            {
                var m1 = new Mitarbeiter() { Name = "Barney" };
                m1.Kunden.Add(new Kunde());
                m1.Kunden.Add(new Kunde());

                var m2 = new Mitarbeiter() { Name = "Fred" };
                m2.Kunden.Add(new Kunde());
                m2.Kunden.Add(new Kunde());
                m2.Kunden.Add(new Kunde());

                var mitarbeiter = new List<Mitarbeiter>();
                mitarbeiter.Add(m1);
                mitarbeiter.Add(m2);

                return mitarbeiter.Cast<T>();
            }

            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }
    }
}