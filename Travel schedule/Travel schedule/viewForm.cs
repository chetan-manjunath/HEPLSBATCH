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
    public partial class viewForm : Form
    {
        SqlConnection sqlConnectionobj;
        SqlCommand selectCommandObj;// insertCommandObj, updateCommandobj, deleteCommandObj;
        SqlDataAdapter sqlDataAdapterObj, sqlDataAdapterObj1;
        DataSet dataSetObj;
        SqlParameter sqlParameterObj1; //sqlParameterObj2, sqlParameterObj3, sqlParameterObj4, sqlParameterObj5, sqlParameterObj6;
      //  DataView dataViewObj;

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select  EmployeeTravelDetails.TravelID, EmployeeDetails.EmployeeID,EmployeeDetails.EmployeeName,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate,Places.PlaceName from EmployeeTravelDetails,Places,EmployeeDetails where EmployeeTravelDetails.ToPlaceID=Places.PlaceID and Places.PlaceName=@placename";
            selectCommandObj.Connection = sqlConnectionobj;

            sqlParameterObj1 = new SqlParameter("@placename", comboBox3.SelectedValue.ToString());
            selectCommandObj.Parameters.Add(sqlParameterObj1);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];

        }

        
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            string selectedPeriod =(string)comboBox2.SelectedValue;
            
            
            if (selectedPeriod == "Week")
            {
                
                selectCommandObj.CommandText = "select  EmployeeTravelDetails.TravelID, EmployeeDetails.EmployeeID,EmployeeDetails.EmployeeName,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate from EmployeeDetails,EmployeeTravelDetails where EmployeeDetails.EmployeeID=EmployeeTravelDetails.EmployeeID and EmployeeTravelDetails.ArrivalDate-GETDATE() between 0 and 7 and EmployeeTravelDetails.DepartureDate-GETDATE() between 0 and 7";
             }
            else
            {
                
                selectCommandObj.CommandText = "select  EmployeeTravelDetails.TravelID, EmployeeDetails.EmployeeID,EmployeeDetails.EmployeeName,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate from EmployeeDetails,EmployeeTravelDetails where EmployeeDetails.EmployeeID=EmployeeTravelDetails.EmployeeID and EmployeeTravelDetails.ArrivalDate-GETDATE() between 0 and 30 and EmployeeTravelDetails.DepartureDate-GETDATE() between 0 and 30";
            }
            
            selectCommandObj.Connection = sqlConnectionobj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }


        public viewForm()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionobj = new SqlConnection(@connectionString);
           
            LoadStatusIntoDropDown();
            LoadTimePeriodIntoDropDown();
            LoadPlaceIntoDropDown();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select EmployeeTravelDetails.TravelID, EmployeeDetails.EmployeeID,EmployeeDetails.EmployeeName,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate,Status.State from EmployeeTravelDetails,Status,EmployeeDetails where EmployeeTravelDetails.StatusID=Status.StatusID and Status.State=@state";
            selectCommandObj.Connection = sqlConnectionobj;

            sqlParameterObj1 = new SqlParameter("@state", comboBox1.SelectedValue.ToString());
            selectCommandObj.Parameters.Add(sqlParameterObj1);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0]; 
 

        }

    private void Button1_Click(object sender, EventArgs e)
        {
            sqlDataAdapterObj1 = new SqlDataAdapter();
            sqlDataAdapterObj1.SelectCommand = new SqlCommand();
            sqlDataAdapterObj1.SelectCommand.CommandText = "select TravelID,EmployeeID,ArrivalDate,DepartureDate,StatusID,FromPlaceID,ToPlaceID from EmployeeTravelDetails";

            sqlDataAdapterObj1.SelectCommand.Connection = sqlConnectionobj;

            dataSetObj = new DataSet();
            sqlDataAdapterObj1.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadStatusIntoDropDown()
        {
            sqlDataAdapterObj = new SqlDataAdapter("select distinct state from Status ", sqlConnectionobj);
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox1.DataSource = dataSetObj.Tables[0];
            comboBox1.DisplayMember = "state";
            comboBox1.ValueMember = "state";
            
        }
        private void LoadTimePeriodIntoDropDown()
        {
            sqlDataAdapterObj = new SqlDataAdapter("select distinct VisitDuration from Period ", sqlConnectionobj);
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox2.DataSource = dataSetObj.Tables[0];
            comboBox2.DisplayMember = "VisitDuration";
            comboBox2.ValueMember = "VisitDuration";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select SerialNumber,Date,StatusID,FromLocalLocationID,ToLocalLocationID,DriverID from LocalSchedule where TravelID=@employeeid";
            selectCommandObj.Connection = sqlConnectionobj;
            sqlParameterObj1 = new SqlParameter("@employeeid", dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
            selectCommandObj.Parameters.Add(sqlParameterObj1);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;

            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView2.DataSource = dataSetObj.Tables[0];

        }

        private void LoadPlaceIntoDropDown()
        {
            sqlDataAdapterObj = new SqlDataAdapter("select distinct PlaceName from Places ", sqlConnectionobj);
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox3.DataSource = dataSetObj.Tables[0];
            comboBox3.DisplayMember = "PlaceName";
            comboBox3.ValueMember = "PlaceName";
        }
    }
}
