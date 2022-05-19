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
    public partial class UpUslugi : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root");
        public UpUslugi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE uslugi set idUslugi='" + textBox2.Text + "', Name ='" + textBox1.Text + "' WHERE idUslugi='" + textBox2.Text + "'";

            connection.Open();
            try
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные изменены");
                }
                else
                {
                    MessageBox.Show("Данные не изменены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        private void UpUslugi_Load(object sender, EventArgs e)
        {
            try
            {

                string selectQuery = "Select * from stomatolog.uslugi";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  textBox2.Text = reader["idUslugi"].ToString();
                  textBox1.Text = reader["Name"].ToString();
             


                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Uslugi = new Uslugi();
            Uslugi.Show();
            this.Hide();
        }
    }
}
