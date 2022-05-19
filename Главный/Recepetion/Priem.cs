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
    public partial class Priem : Form
    {
        public Priem()
        {
            InitializeComponent();
        }

        private void Priem_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT idPriem'ID', Data'Дата', Time as 'Время', klient.FIO'ФИО пациента', sotrud.FIO'ФИО врача',Sumuslug'Общая стоимость',Uslugi'Услуги' from stomatolog.Priem, stomatolog.klient, stomatolog.sotrud where priem.klientID=klient.idKlient and priem.sotrudID=sotrud.id ", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Priem");
                dataGridView1.DataSource = ds.Tables["Priem"];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            Form NewPriem = new NewPriem();
            NewPriem.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form UpPriem = new UpPriem();
            UpPriem.Show();
            this.Hide();
        }
    }
}
