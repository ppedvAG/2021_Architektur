// See https://aka.ms/new-console-template for more information
using Autofac;
using ppedv.Personenverwaltung.Data.EfCore;
using ppedv.Personenverwaltung.Logik;
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contacts;
using System.Reflection;

Console.WriteLine("Hello, World!");

//DI direkt per Referenz
//var core = new Core(new ppedv.Personenverwaltung.Data.EfCore.EfRepository());

//DI per hand per Reflection
//var path = @"C:\Users\Fred\source\repos\ppedvAG\2021_Architektur\ppedv.Personenverwaltung\ppedv.Personenverwaltung.Data.EfCore\bin\Debug\net6.0\ppedv.Personenverwaltung.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitDemRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//IRepository repo = (IRepository)Activator.CreateInstance(typeMitDemRepo);
//var core = new Core(repo);

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfRepository>().AsImplementedInterfaces();
var container = builder.Build();

var core = new Core(container.Resolve<IRepository>());

var kunden = core.GetKundenThatHaveBirtdayThatMonth(1);

foreach (var k in kunden)
{
    Console.WriteLine($"{k.Name}");
}

Console.WriteLine("Abteilungen");
foreach (var abt in core.Repository.GetAll<Abteilung>())
{
    Console.WriteLine($"{abt.Bezeichnung}");
    foreach (var m in abt.Mitarbeiter)
    {
        Console.WriteLine($"\t{m.Name}");
    }
}

