// See https://aka.ms/new-console-template for more information
using ppedv.Personenverwaltung.Logik;
using ppedv.Personenverwaltung.Model;

Console.WriteLine("Hello, World!");

var core = new Core();

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

