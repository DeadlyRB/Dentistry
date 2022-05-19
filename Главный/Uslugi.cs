using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Главный
{
    public partial class Uslugi : Form
    {
        public Uslugi()
        {
            InitializeComponent();
        }

        private void Uslugi_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * from stomatolog.uslugi", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Uslugi");
                dataGridView1.DataSource = ds.Tables["Uslugi"];
                connection.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Glav = new Glav();
            Glav.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form NewUslugi = new NewUslugi();
            NewUslugi.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form UpUslugi = new UpUslugi();
            UpUslugi.Show();
            this.Hide();
        }
    }
}
