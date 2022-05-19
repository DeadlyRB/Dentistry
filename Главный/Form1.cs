using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Главный
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Sotrud = new Sotrud();
            Sotrud.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                Form Klient = new Klient();
                Klient.Show();
                this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Uslugi = new Uslugi();
            Uslugi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Priem= new Priem();
            Priem.Show();
            this.Hide();
        }
    }
}
