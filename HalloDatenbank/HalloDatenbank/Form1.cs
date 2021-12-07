using Microsoft.Data.SqlClient;

namespace HalloDatenbank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conStringMitSSL = "Server=.;Database=NORTHWND;Trusted_Connection=true;trustservercertificate=true";
            string conString = "Server=.;Database=NORTHWND;Trusted_Connection=true;encrypt=false";
            conString = "Server=(localdb)\\mssqllocaldb;Database=NORTHWND;Trusted_Connection=true";
            
            var con = new SqlConnection(conString);
            
            con.Open();

        }
    }
}