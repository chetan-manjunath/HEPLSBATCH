using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel_schedule
{
    public partial class viewForm : Form
    {
        SqlConnection sqlConnectionobj;
        //SqlCommand sqlCommandObj, selectCommandObj, insertCommandObj, updateCommandobj, deleteCommandObj;
        SqlDataAdapter sqlDataAdapterObj;
        DataSet dataSetObj;
        //SqlParameter sqlParameterObj1, sqlParameterObj2, sqlParameterObj3, sqlParameterObj4, sqlParameterObj5, sqlParameterObj6;
        //DataView dataViewObj;
        public viewForm()
        {
            InitializeComponent();
            sqlConnectionobj = new SqlConnection(@"Data Source=BLR-JDXDG32-L\SQLSERVER12;Initial Catalog=TravelScheduleDB;User ID=sa;Password=W3lc0m3");
            sqlDataAdapterObj = new SqlDataAdapter();
            sqlDataAdapterObj.SelectCommand = new SqlCommand();
            sqlDataAdapterObj.SelectCommand.CommandText = "select * from EmployeeTravelDetailTable";
            sqlDataAdapterObj.SelectCommand.Connection = sqlConnectionobj;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
