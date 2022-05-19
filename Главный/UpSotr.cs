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
    public partial class UpSotr : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root");
        public UpSotr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE sotrud set sotrud.id ='" + textBox2.Text + "',FIO ='" + textBox1.Text + "',DataYear ='" + maskedTextBox1.Text + "',Pol ='" + comboBox1.Text + "',Telephone ='" + maskedTextBox2.Text + "', Adress ='" + textBox5.Text + "',VidDocum='" + comboBox2.Text + "',SeriesPas ='" + maskedTextBox3.Text + "', Pasport='" + maskedTextBox4.Text + "', KemVud='" + textBox9.Text + "', datavud='" + maskedTextBox7.Text + "', dolgnost ='" +textBox10.Text +"', DataUstr ='" + maskedTextBox5.Text + "', DataUvol ='" + maskedTextBox6.Text + "' WHERE sotrud.id='" + int.Parse(textBox2.Text) + "'";
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form Sotrud = new Sotrud();
            Sotrud.Show();
            this.Hide();
        }

        private void UpSotr_Load(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    maskedTextBox1.Select(0, 0);
                });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {

                    string selectQuery = "Select * from stomatolog.sotrud, stomatolog.viddoc where sotrud.id='"+textBox2.Text+"'";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        textBox1.Text = reader["FIO"].ToString();
                        maskedTextBox1.Text = reader["DataYear"].ToString();
                        comboBox1.Text = reader["Pol"].ToString();
                        maskedTextBox2.Text = reader["Telephone"].ToString();
                        textBox5.Text = reader["Adress"].ToString();

                        maskedTextBox3.Text = reader["SeriesPas"].ToString();
                        maskedTextBox4.Text = reader["Pasport"].ToString();
                        textBox9.Text = reader["KemVud"].ToString();
                        textBox10.Text = reader["Dolgnost"].ToString();
                        maskedTextBox5.Text = reader["DataUstr"].ToString();
                        maskedTextBox6.Text = reader["DataUvol"].ToString();


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
