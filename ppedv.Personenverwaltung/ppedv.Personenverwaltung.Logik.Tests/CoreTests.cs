using Moq;
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace ppedv.Personenverwaltung.Logik.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetMitarbeiterWithMostKunden_Mitarbeiter_empty()
        {
            var mock = new Mock<IRepository>();
            var core = new Core(mock.Object);

            var result = core.GetMitarbeiterWithMostKunden();

            Assert.Null(result);
        }

        [Fact]
        public void GetMitarbeiterWithMostKunden_2_Mitarbeiter_Fred_has_more_Kunden_TestRepo()
        {
            var core = new Core(new TestRepo()); ;

            var result = core.GetMitarbeiterWithMostKunden();

            Assert.Equal("Fred", result.Name);
        }

        [Fact]
        public void GetMitarbeiterWithMostKunden_2_Mitarbeiter_Fred_has_more_Kunden_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Mitarbeiter>()).Returns(() =>
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

                return mitarbeiter;
            });
            var core = new Core(mock.Object); 

            var result = core.GetMitarbeiterWithMostKunden();

            Assert.Equal("Fred", result.Name);
        }


        [Fact]
        public void GetMitarbeiterWithMostKunden_2_Mitarbeiter_same_Kunden_count_result_Barney()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Mitarbeiter>()).Returns(() =>
            {
                var m1 = new Mitarbeiter() { Name = "Barney" };
                m1.Kunden.Add(new Kunde());
                m1.Kunden.Add(new Kunde());

                var m2 = new Mitarbeiter() { Name = "Fred" };
                m2.Kunden.Add(new Kunde());
                m2.Kunden.Add(new Kunde());

                var mitarbeiter = new List<Mitarbeiter>();
                mitarbeiter.Add(m2);
                mitarbeiter.Add(m1);

                return mitarbeiter;
            });
            var core = new Core(mock.Object);

            var result = core.GetMitarbeiterWithMostKunden();

            Assert.Equal("Barney", result.Name);

            mock.Verify(x => x.GetAll<Mitarbeiter>(), Times.Exactly(1));
        }

    }
}