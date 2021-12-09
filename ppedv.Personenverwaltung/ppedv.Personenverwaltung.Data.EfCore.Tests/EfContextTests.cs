using ppedv.Personenverwaltung.Model;
using System;
using Xunit;

namespace ppedv.Personenverwaltung.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        [Trait("", "Integration")]
        public void Can_create_db()
        {
            using var context = new EfContext();
            context.Database.EnsureDeleted();

            Assert.True(context.Database.EnsureCreated());
        }

        [Fact]
        [Trait("", "Integration")]
        public void Can_CRUD_Kunde()
        {
            //Can_create_db();
            var kunde = new Kunde() { KdNummer = "0001", Name = $"Wilma_{Guid.NewGuid()}" };
            string newName = $"Fred_{Guid.NewGuid()}";

            //CREATE
            using (var context = new EfContext())
            {
                context.Add(kunde);
                Assert.Equal(2, context.SaveChanges());
            }

            //READ
            using (var context = new EfContext())
            {
                var loaded = context.Kunden.Find(kunde.Id);
                Assert.NotNull(loaded);
                Assert.Equal(kunde.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                Assert.Equal(1, context.SaveChanges());
            }

            //check UPDATE
            using (var context = new EfContext())
            {
                var loaded = context.Kunden.Find(kunde.Id);
                Assert.Equal(newName, loaded.Name);

                //DELETE
                context.Remove(loaded);
                Assert.Equal(2, context.SaveChanges());
            }

            //check DELETE
            using (var context = new EfContext())
            {
                var loaded = context.Kunden.Find(kunde.Id);
                Assert.Null(loaded);
            }
        }
    }
}