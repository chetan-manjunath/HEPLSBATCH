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
        ViewController controllerObj;                        //  DataView dataViewObj;
        public viewForm()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionobj = new SqlConnection(@connectionString);
            controllerObj = new ViewController();
            LoadStatusIntoDropDown();
            LoadTimePeriodIntoDropDown();
            LoadPlaceIntoDropDown();
        }


        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlacesModel placesObj = new PlacesModel(comboBox3.SelectedValue.ToString());
            controllerObj = new ViewController();
            dataSetObj = controllerObj.travelEmployee(placesObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];

        }

        
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPeriod =(string)comboBox2.SelectedValue;
            controllerObj = new ViewController();
            dataSetObj =  controllerObj.FilterPeriod(selectedPeriod);
            
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }


   
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var value = comboBox1.SelectedValue.ToString();
            dataSetObj= controllerObj.employeestate(value);
            dataGridView1.DataSource = dataSetObj.Tables[0];


        }

    private void Button1_Click(object sender, EventArgs e)
        {
            controllerObj = new ViewController();
            dataSetObj = controllerObj.ViewEmployeeTravelDetails();
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.Refresh();
            this.Close();
        }
        private void LoadStatusIntoDropDown()
        {
            controllerObj = new ViewController();
            dataSetObj = controllerObj.LoadStatusIntoDropDown();

            comboBox1.DataSource = dataSetObj.Tables[0];
            comboBox1.DisplayMember = "State";
            comboBox1.ValueMember = "StatusID";
            
        }
        private void LoadTimePeriodIntoDropDown()
        {
            controllerObj = new ViewController();
            dataSetObj = controllerObj.LoadTimePeriodIntoDropDown();

            comboBox2.DataSource = dataSetObj.Tables[0];
            comboBox2.DisplayMember = "VisitDuration";
            comboBox2.ValueMember = "VisitDuration";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var value = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            controllerObj = new ViewController();
             dataSetObj =  controllerObj.localTravel(value);
            dataGridView2.DataSource = dataSetObj.Tables[0];

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadPlaceIntoDropDown()
        {
            controllerObj = new ViewController();
            dataSetObj = controllerObj.LoadPlaceIntoDropDown();

            comboBox3.DataSource = dataSetObj.Tables[0];
            comboBox3.DisplayMember = "PlaceName";
            comboBox3.ValueMember = "PlaceID";
        }
    }
}
