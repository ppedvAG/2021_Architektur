using Microsoft.Data.SqlClient;
using System.Diagnostics;

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

            List<Mitarbeiter> list = new List<Mitarbeiter>();
            try
            {

                var sw = new Stopwatch();
                sw.Start();
                using (var con = new SqlConnection(conString))
                {
                    con.Open();

                    using (var countCmd = con.CreateCommand())
                    {
                        countCmd.CommandText = "SELECT COUNT(*) FROM Employees";
                        var count = countCmd.ExecuteScalar();
                        label1.Text = $"{count} Employees in DB";
                    }

                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Employees";
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string vorname = reader.GetString(2); //ok
                            string nachname = reader["LastName"].ToString(); // doof
                            DateTime gebDatum = reader.GetDateTime(reader.GetOrdinal("BirthDate")); //beste

                            var mit = new Mitarbeiter() { Vorname = vorname, Nachname = nachname, GebDatum = gebDatum };
                            list.Add(mit);
                        }

                        dataGridView1.DataSource = list;
                        sw.Stop();
                        label1.Text = $"{sw.ElapsedMilliseconds}ms";
                    }

                } //con.Dispose(); //--> con.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
                //MessageBox.Show(String.Format("Error: {0}", ex.Message));
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

    }
}