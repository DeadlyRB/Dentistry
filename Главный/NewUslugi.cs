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
    public partial class NewUslugi : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root");
        public NewUslugi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 

            connection.Open();
            string InsertQuery = "INSERT INTO uslugi(name) VALUES ('" + textBox1.Text + "')";


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
            Form Uslugi = new Uslugi();
            Uslugi.Show();
            this.Hide();
        }
    }
}
