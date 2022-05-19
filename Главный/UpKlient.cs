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
    public partial class UpKlient : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root");
        public UpKlient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE klient set idKlient ='" + textBox2.Text +"',FIO ='" + textBox1.Text +"',DataYear ='" + maskedTextBox2.Text +"',Adress ='" + textBox3.Text +"',Telephone ='" + maskedTextBox1.Text +"',Snils ='" + maskedTextBox3.Text +"',INN ='"+ maskedTextBox4.Text+ "',MedPolis ='" + maskedTextBox5.Text +"',VidDocum ='" + comboBox1.Text +"',Pasport ='" + maskedTextBox7.Text +"',SeriesPas ='" + maskedTextBox8.Text + "' WHERE idKlient='"+textBox2.Text+"'";

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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            connection.Close();
        }
        private void UpKlient_Load(object sender, EventArgs e)
        {
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

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {

                    string selectQuery = "Select * from stomatolog.klient, stomatolog.viddoc where klient.idKlient='" + textBox2.Text + "'";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        textBox1.Text = reader["FIO"].ToString();
                        maskedTextBox2.Text = reader["DataYear"].ToString();
                        textBox3.Text = reader["Adress"].ToString();
                        maskedTextBox1.Text = reader["Telephone"].ToString();
                        maskedTextBox3.Text = reader["Snils"].ToString();
                        maskedTextBox4.Text = reader["INN"].ToString();
                        maskedTextBox5.Text = reader["MedPolis"].ToString();
                        comboBox1.Text = reader["VidDocum"].ToString();
                        maskedTextBox8.Text = reader["SeriesPas"].ToString();
                        maskedTextBox7.Text = reader["Pasport"].ToString();
                            


                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
