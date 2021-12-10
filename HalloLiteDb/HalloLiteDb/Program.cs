// See https://aka.ms/new-console-template for more information
using LiteDB;

Console.WriteLine("Hello, World!");

var db = new LiteDatabase(@"C:\Users\Fred\Documents\test123.db");



var col = db.GetCollection<Customer>("customers");

var customer = new Customer
{
    Name = "John D111oe",
    //Phones = new string[] { "8000-0000", "9000-0000" },
    IsActive = true,
    Zahl = 12,
    Boss = new Customer() { Name="BOSS!!!"}
};


col.Insert(customer);






public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public bool IsActive { get; set; }
    public int Zahl { get; set; }

    public Customer Boss { get; set; }
}
