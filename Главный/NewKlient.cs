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
    public partial class NewKlient : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root");
        public NewKlient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.Open();
            string InsertQuery = "INSERT INTO klient(FIO, DataYear,Adress,Telephone,Snils,INN,MedPolis,VidDocum,Pasport,SeriesPas) VALUES ('" + textBox1.Text + "','" + maskedTextBox2.Text + "','"+ textBox3.Text + "','" +maskedTextBox1.Text + "','" + maskedTextBox3.Text + "','" + maskedTextBox4.Text + "','" + maskedTextBox5.Text + "','" + comboBox1.Text + "','" + maskedTextBox7.Text + "','" + maskedTextBox8.Text + "')";


            MySqlCommand command = new MySqlCommand(InsertQuery, connection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные внесены");
                }
                else
                {
                    MessageBox.Show("Данные не записанны");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Klient = new Klient();
            Klient.Show();
            this.Hide();

        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
              try
            {
                string selectQuery = "SELECT * from viddoc";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("name"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
    }
}
