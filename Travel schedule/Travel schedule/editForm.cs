using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Travel_schedule
{
    public partial class editForm : Form
    {
        SqlConnection sqlConnectionObj;
        SqlCommand sqlCommandObj,selectCommandObj;
        SqlDataAdapter sqlDataAdapterObj;
        SqlParameter sqlParameterObj;
        DataSet dataSetObj;

        public editForm()
        {
            InitializeComponent();
            sqlConnectionObj = new SqlConnection(@"Data Source=BLR-PG00MPY1-L;Initial Catalog=TravelScheduleDB;Integrated Security=True");
            loadPlaces();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadPlaces()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select Distinct PlaceName from Places";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox4.DataSource = dataSetObj.Tables[0];
            comboBox4.DisplayMember = "PlaceName";
            comboBox4.ValueMember = "PlaceName";
        }

    }
}
