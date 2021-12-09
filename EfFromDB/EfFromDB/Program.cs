// See https://aka.ms/new-console-template for more information
using EfFromDB;

Console.WriteLine("Hello, World!");


var con = new HalloEFContext();
foreach (var emp in con.Employees)
{
    Console.WriteLine(emp.Beruf);
}