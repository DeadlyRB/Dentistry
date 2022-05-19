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
    public partial class UpPriem : Form
    { MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root");
        public UpPriem()
        {
           
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
                string updateQuery = "UPDATE sotrud set priem.idPriem ='" + textBox2.Text + "',FIO ='" + textBox1.Text + "',Data ='" + maskedTextBox1.Text + "',Time ='" + maskedTextBox2.Text + "'KlientID ='" + comboBox1.Text + "', SotrudID ='" + comboBox2.Text + "',Uslugi='" + comboBox3.Text + "',SumUslug ='" + textBox1.Text + "' WHERE priem.id='" + int.Parse(textBox2.Text) + "'";

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

        private void button3_Click(object sender, EventArgs e)
        {                try
                {

                    string selectQuery = "Select * from stomatolog.priem, stomatolog.sotrud, stomatolog.klient where priem.idPriem='" + textBox2.Text + "'";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        textBox1.Text = reader["FIO"].ToString();
                        maskedTextBox1.Text = reader["Data"].ToString();
                        maskedTextBox2.Text = reader["Time"].ToString();
                        comboBox1.Text = reader["KlientID"].ToString();
                        comboBox2.Text = reader["SotrudID"].ToString();
                        comboBox3.Text = reader["Uslugi"].ToString();
                        textBox1.Text = reader["SumUslug"].ToString();



                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {

            try
            {
                comboBox1.Items.Clear();
                string selectQuery = "SELECT * from klient";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("FIO"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {

            try
            {
                comboBox2.Items.Clear();
                string selectQuery = "SELECT * from sotrud";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("FIO"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {

            try
            {
                comboBox3.Items.Clear();
                string selectQuery = "SELECT * from uslugi";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("name"));
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
            Form Priem = new Priem();
            Priem.Show();
            this.Hide();
        }
    }
}
