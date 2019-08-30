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
using System.Configuration;

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
       int employeeID,TravelID;
        LocalTravelForm LocalObj;



        public editForm()
        {
            InitializeComponent();
            LocalTravelForm LocalObj;
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionObj = new SqlConnection(@connectionString);
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
            selectCommandObj.CommandText = "select * from EmployeeTravelDetails where EmployeeID=@employeeID";
            employeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            TravelID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            selectCommandObj.Connection = sqlConnectionObj;
            //MessageBox.Show(sqlParameterObj.Value.ToString());
            selectCommandObj.Parameters.Add(sqlParameterObj);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            //arrivalDate = Convert.ToDateTime(dateTimePicker1.Value);
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            //depatureDate = Convert.ToDateTime(dateTimePicker2.Value);
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            LocalObj = new LocalTravelForm(this.TravelID);
            this.Visible = false;
            DialogResult dr = LocalObj.ShowDialog(this);
            this.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //TimeSpan result = dateTimePicker2.Value.Subtract(dateTimePicker1.Value);
            //double date = result.TotalDays;
            double date = dateTimePicker2.Value.Subtract(dateTimePicker1.Value).TotalDays;
            if (date > 0)
            {
                try
                {
                    sqlDataAdapterObj = new SqlDataAdapter();
                    updateCommandObj = new SqlCommand();
                    updateCommandObj.CommandText = "update EmployeeTravelDetails set ArrivalDate=@arrivalDate,DepartureDate=@depatureDate where EmployeeID=@employeeId";
                    updateCommandObj.Connection = sqlConnectionObj;
                    sqlParameterObj2 = new SqlParameter("@arrivalDate", Convert.ToDateTime(dateTimePicker1.Value));
                    sqlParameterObj3 = new SqlParameter("@depatureDate", Convert.ToDateTime(dateTimePicker2.Value));
                    sqlParameterObj = new SqlParameter("@employeeId", employeeID);
                    updateCommandObj.Parameters.Add(sqlParameterObj2);
                    updateCommandObj.Parameters.Add(sqlParameterObj3);
                    updateCommandObj.Parameters.Add(sqlParameterObj);

                    sqlDataAdapterObj.SelectCommand = selectCommandObj;
              
                    sqlConnectionObj.Open();
                    updateCommandObj.ExecuteNonQuery();
                    ComboBox4_SelectedIndexChanged(sender, e);
                }
                catch (Exception er) { MessageBox.Show("Select the employee first");
                    ComboBox4_SelectedIndexChanged(sender, e);
                }
                sqlConnectionObj.Close();
            }
            else
            {
                MessageBox.Show("Please select the correct departure date");
                ComboBox4_SelectedIndexChanged(sender, e);
            }
           

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
