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
    public partial class Glav : Form
    {
        
        public Glav()
        {
            InitializeComponent();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Sotrud = new Sotrud();
            Sotrud.Show();
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form Klient = new Klient();
            Klient.Show();
            this.Hide();
        }

        private void журналУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Uslugi = new Uslugi();
            Uslugi.Show();
            this.Hide();
        }

        private void приёмнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Priem = new Priem();
            Priem.Show();
            this.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, FormClosingEventArgs e)
        {
            const string message =
                "Вы действительно хотите выйти из приложения?";
            const string caption = "";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                e.Cancel = true;
            }
        }

        private void материалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form material = new material();
            material.Show();
            this.Hide();
        }
    }
}
