using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel_schedule
{
    public partial class LocalTravelForm : Form
    {
        SqlConnection sqlConnectionObj;
        SqlCommand sqlCommandObj, selectCommandObj;
        SqlDataAdapter sqlDataAdapterObj;
        SqlParameter sqlParameterObj;
        DataSet dataSetObj;
        public LocalTravelForm(int id)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionObj = new SqlConnection(@connectionString);
            Scheduledetails(id);
        }
        public void Scheduledetails(int id)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select * from LocalSchedule l where l.TravelID=@Id";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlParameterObj = new SqlParameter("@Id", id);
            selectCommandObj.Parameters.Add(sqlParameterObj);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }
    }
}
