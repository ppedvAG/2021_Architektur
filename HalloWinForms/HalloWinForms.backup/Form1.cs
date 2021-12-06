using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.DataBindings.Add("Text", textBox1, "Text",
                        true, DataSourceUpdateMode.OnPropertyChanged);

            textBox2.DataBindings.Add("BackColor", textBox1, "Text",
                        true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Hallo {textBox1.Text}");
        }
    }
}
