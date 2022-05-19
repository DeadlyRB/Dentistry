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
    public partial class NewSotrud : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root; convert zero datetime=True");
        public NewSotrud()
        {
         InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string InsertQuery = "INSERT INTO sotrud(FIO,DataYear,Pol,Telephone,Adress,VidDocum,DataVud,SeriesPas,Pasport,KemVud,Dolgnost,DataUstr,DataUvol) VALUES ('" + textBox1.Text + "','" +maskedTextBox1.Text + "','" + comboBox1.Text + "','" + maskedTextBox2.Text + "','" + textBox5.Text + "','" +comboBox2.Text + "','" +maskedTextBox7.Text+"','"+maskedTextBox3.Text + "','" + maskedTextBox4.Text + "','" + textBox9.Text +"','"+ textBox10.Text + "','"+ maskedTextBox5.Text + "','"+ maskedTextBox6.Text + "')";



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

        private void NewSotrud_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Sotrud = new Sotrud();
            Sotrud.Show();
            this.Hide();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            try
                
            {
                comboBox2.Items.Clear();
                connection.Open();
                string selectQuery = "SELECT * from viddoc";
                
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("name"));
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
