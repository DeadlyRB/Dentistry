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
    public partial class Klient : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
        public Klient()
        {
            InitializeComponent();
        }

        private void Klient_Load(object sender, EventArgs e)
        {
            try
            {
                
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * from stomatolog.Klient", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Klient");
                dataGridView1.DataSource = ds.Tables["Klient"];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Form NewKlient = new NewKlient();
            NewKlient.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form Glav = new Glav();
            Glav.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form UpKlient= new UpKlient();
            UpKlient.Show();
            this.Hide();
        }
    }
}
