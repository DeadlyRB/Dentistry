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
    public partial class NewPriem : Form
    {
        private int KlientID;
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=stomatolog;port=3306;username=root;password=root");
        public NewPriem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form Priem = new Priem();
            Priem.Show();
            this.Hide();
        }


        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            connection.Open();
            MySqlCommand Cmd = new MySqlCommand("select idKlient, FIO from klient order by FIO", connection);
            MySqlDataReader reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetValue(0).ToString() + "," + reader.GetValue(1).ToString());
            }
            reader.Close();
            connection.Close();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                connection.Open();
                string selectQuery1 = "SELECT * from sotrud";
                MySqlCommand command = new MySqlCommand(selectQuery1, connection);
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

        private void combobox3_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox3.Items.Clear();
                connection.Open();
                string selectQuery3 = "SELECT * from uslugi";
                MySqlCommand command = new MySqlCommand(selectQuery3, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("Name"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KlientID = Int32.Parse(comboBox1.Text.Substring(0, comboBox1.Text.IndexOf('.')));
        }
    }
}
