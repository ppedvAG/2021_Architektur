using HalloEFCore.Data;
using System.Linq;
using System.Windows;

namespace HalloEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadAll(object sender, RoutedEventArgs e)
        {
            var con = new EfContext();
            con.Database.EnsureCreated();

            myGrid.ItemsSource = con.Mitarbeiter.Where(x => x.GebDatum.Month == 11).ToList();
        }
    }
}
