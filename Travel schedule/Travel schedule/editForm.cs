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
        SqlCommand sqlCommandObj,selectCommandObj, updateCommandObj;
        SqlDataAdapter sqlDataAdapterObj;
        SqlParameter sqlParameterObj;
        DataSet dataSetObj;
         SqlParameter sqlParameterObj1;
         SqlParameter sqlParameterObj2;
          SqlParameter sqlParameterObj3;
        static DateTime arrivalDate;
        static DateTime depatureDate;
        static int employeeID;



        public editForm()
        {
            InitializeComponent();
            sqlConnectionObj = new SqlConnection(@"Data Source=BLR-PG00HCSH-L;Initial Catalog=TravelScheduleDB;User ID=sa;Password=W3lc0m3");
            loadPlaces();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select * from EmployeeTravelDetails as eTD,Places as P where P.PlaceID=eTD.ToPlaceID and P.PlaceName = @placename ";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlParameterObj = new SqlParameter("@placename", comboBox4.SelectedValue);
            selectCommandObj.Parameters.Add(sqlParameterObj);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            sqlParameterObj = new SqlParameter("@employeeID", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            selectCommandObj.CommandText = "select * from EmployeeTravelDetails where EmloyeeID=@employeeID";
            employeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            selectCommandObj.Connection = sqlConnectionObj;
            //MessageBox.Show(sqlParameterObj.Value.ToString());
            selectCommandObj.Parameters.Add(sqlParameterObj);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlParameterObj1 = new SqlParameter("@driverName", comboBox1.SelectedValue);

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            arrivalDate = Convert.ToDateTime(dateTimePicker1.Value);
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            depatureDate = Convert.ToDateTime(dateTimePicker2.Value);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            updateCommandObj = new SqlCommand();
            updateCommandObj.CommandText = "update EmployeeTravelDetails set ArrivalDate=@arrivalDate,DepartureDate=@depatureDate where EmloyeeID=@employeeId";
            updateCommandObj.Connection = sqlConnectionObj;
            sqlParameterObj2 = new SqlParameter("@arrivalDate", arrivalDate);
            sqlParameterObj3 = new SqlParameter("@depatureDate", depatureDate);
            sqlParameterObj = new SqlParameter("@employeeId", employeeID);
            updateCommandObj.Parameters.Add(sqlParameterObj2);
            updateCommandObj.Parameters.Add(sqlParameterObj3);
            updateCommandObj.Parameters.Add(sqlParameterObj);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            sqlConnectionObj.Open();
            updateCommandObj.ExecuteNonQuery();
            sqlConnectionObj.Close();

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
