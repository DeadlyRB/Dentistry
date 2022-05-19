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
    public partial class material : Form
    {
        public material()
        {
            InitializeComponent();
        }

        private void material_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root;database=stomatolog");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT idMaterials'ID',name'Название',Kolvo'Количество',PriceOnEd'Цена за единицу' from materials", connection);

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
    }
}
