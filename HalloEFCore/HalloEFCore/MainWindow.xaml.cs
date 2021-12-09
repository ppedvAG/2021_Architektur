using HalloEFCore.Data;
using HalloEFCore.Model;
using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace HalloEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EfContext _context = new EfContext();

        public MainWindow()
        {
            InitializeComponent();
            _context.Database.EnsureCreated();
             
        }

        private void LoadAll(object sender, RoutedEventArgs e)
        {
            var query = from m in _context.Mitarbeiter
                        where m.Name.StartsWith("F")
                        orderby m.GebDatum.Month descending, m.GebDatum.Year
                        select m;
            //select new { DerName = m.Name, BIRTHDATE = m.GebDatum, Monat = m.GebDatum.Month };

            myGrid.ItemsSource = query.ToList();

            int count = _context.Mitarbeiter.Count(x => x.Abteilungen.Count() > 1);
            MessageBox.Show(count.ToString());

            MessageBox.Show(query.ToQueryString());

            //myGrid.ItemsSource = _context.Mitarbeiter.Include(x => x.Abteilungen).ToList();
        }

        private void LoadAllLambda(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = _context.Mitarbeiter
                                         .Where(x => x.Name.StartsWith("F"))
                                         .OrderByDescending(x => x.GebDatum.Month)
                                         .ThenBy(x => x.GebDatum.Year)
                                         .Select(x => x.Name)
                                         .ToList();
        }

        private void FirstOfMay(object sender, RoutedEventArgs e)
        {
            Mitarbeiter? mitarbeiter = _context.Mitarbeiter.FirstOrDefault(x => x.GebDatum.Month == 5);
            if (mitarbeiter != null)
                MessageBox.Show(mitarbeiter.Name);
            else
                MessageBox.Show("Nix gefunden");
        }

        private void CreateDemodata(object sender, RoutedEventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Name = $"Fred #{i:0000}",
                    GebDatum = DateTime.Now.AddYears(-40).AddDays(i * 17),
                    Job = "Macht zeug"
                };

                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);

                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                _context.Mitarbeiter.Add(m);
            }
            _context.SaveChanges();
        }

        private void SaveAll(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
