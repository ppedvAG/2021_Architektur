// See https://aka.ms/new-console-template for more information
using ppedv.Personenverwaltung.Logik;

Console.WriteLine("Hello, World!");

var core = new Core();

var kunden = core.GetKundenThatHaveBirtdayThatMonth(1);

foreach (var k in kunden)
{
    Console.WriteLine($"{k.Name}");
}

