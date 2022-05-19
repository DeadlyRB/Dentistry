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
    public partial class Sotrud : Form
    {
        public Sotrud()
        {
            InitializeComponent();
        }
        private void Sotrud_Load(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root;convert zero datetime=True");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT id'ID',FIO'ФИО сотрудника',DataYear'Дата рождения',Pol'Пол',Telephone'Телефон',Adress'Адрес',VidDocum'Вид документа',SeriesPas'Серия',Pasport'Номер',KemVud'Кем выдан',DataVud'Дата выдачи',Dolgnost'Должность',DataUstr'Дата устройства',DataUvol'Дата увольнения' from stomatolog.sotrud", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "sotrud");
                dataGridView1.DataSource = ds.Tables["sotrud"];
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
            Form NewSotrud = new NewSotrud();
            NewSotrud.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form UpSotr = new UpSotr();
            UpSotr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Form UpSotr = new UpSotr();
            UpSotr.Show();
            this.Hide();
        }
    }
}
