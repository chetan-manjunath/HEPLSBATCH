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
        SqlCommand sqlCommandObj, selectCommandObj, updateCommandObj;
        SqlDataAdapter sqlDataAdapterObj;
        SqlParameter sqlParameterObj, sqlParameterObj1;
        DataSet dataSetObj;
        int TravelID;
        int SerialNumber;
        public LocalTravelForm(int id)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionObj = new SqlConnection(@connectionString);
            Scheduledetails(id);
            TravelID = id;
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            SerialNumber= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            loadFromLocation();
            loadToLocation();
            loadStatus();
            loadDriver();


        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int toLocation = Convert.ToInt32(comboBox2.SelectedValue);
                sqlDataAdapterObj = new SqlDataAdapter();
                updateCommandObj = new SqlCommand();
                sqlParameterObj = new SqlParameter("@Id", toLocation);
                sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
                updateCommandObj.Parameters.Add(sqlParameterObj);
                updateCommandObj.Parameters.Add(sqlParameterObj1);
                //MessageBox.Show(fromLocation + "   " + SerialNumber);
                updateCommandObj.CommandText = "update LocalSchedule set ToLocalLocationID = @Id where SerialNumber=@slno";
                updateCommandObj.Connection = sqlConnectionObj;
                sqlConnectionObj.Open();
                updateCommandObj.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally
            {
                sqlConnectionObj.Close();
                Scheduledetails(TravelID);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                int driverID = Convert.ToInt32(comboBox4.SelectedValue);
                sqlDataAdapterObj = new SqlDataAdapter();
                updateCommandObj = new SqlCommand();
                sqlParameterObj = new SqlParameter("@Id", driverID);
                sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
                updateCommandObj.Parameters.Add(sqlParameterObj);
                updateCommandObj.Parameters.Add(sqlParameterObj1);
                //MessageBox.Show(fromLocation + "   " + SerialNumber);
                updateCommandObj.CommandText = "update LocalSchedule set DriverID = @Id where SerialNumber=@slno";
                updateCommandObj.Connection = sqlConnectionObj;
                sqlConnectionObj.Open();
                updateCommandObj.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally
            {
                sqlConnectionObj.Close();
                Scheduledetails(TravelID);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int fromLocation = Convert.ToInt32(comboBox1.SelectedValue);
                sqlDataAdapterObj = new SqlDataAdapter();
                updateCommandObj = new SqlCommand();
                sqlParameterObj = new SqlParameter("@Id", fromLocation);
                sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
                updateCommandObj.Parameters.Add(sqlParameterObj);
                updateCommandObj.Parameters.Add(sqlParameterObj1);
                //MessageBox.Show(fromLocation + "   " + SerialNumber);
                updateCommandObj.CommandText = "update LocalSchedule set FromLocalLocationID = @Id where SerialNumber=@slno";
                updateCommandObj.Connection = sqlConnectionObj;
                sqlConnectionObj.Open();
                updateCommandObj.ExecuteNonQuery();
                
            }
            catch (Exception ex) {  }
            finally { sqlConnectionObj.Close();
                Scheduledetails(TravelID);
            }
            
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int StatusID = Convert.ToInt32(comboBox3.SelectedValue);
                sqlDataAdapterObj = new SqlDataAdapter();
                updateCommandObj = new SqlCommand();
                sqlParameterObj = new SqlParameter("@Id",StatusID);
                sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
                updateCommandObj.Parameters.Add(sqlParameterObj);
                updateCommandObj.Parameters.Add(sqlParameterObj1);
                //MessageBox.Show(fromLocation + "   " + SerialNumber);
                updateCommandObj.CommandText = "update LocalSchedule set StatusID = @Id where SerialNumber=@slno";
                updateCommandObj.Connection = sqlConnectionObj;
                sqlConnectionObj.Open();
                updateCommandObj.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally
            {
                sqlConnectionObj.Close();
                Scheduledetails(TravelID);
            }
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
        public void loadFromLocation()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox1.DataSource = dataSetObj.Tables[0];
            comboBox1.DisplayMember = "Place";
            comboBox1.ValueMember = "LocationID";
        }

        public void loadToLocation()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox2.DataSource = dataSetObj.Tables[0];
            comboBox2.DisplayMember = "Place";
            comboBox2.ValueMember = "LocationID";
        }

        public void loadStatus()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select StatusID,State from Status ";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox3.DataSource = dataSetObj.Tables[0];
            comboBox3.DisplayMember = "State";
            comboBox3.ValueMember = "StatusID";
        }

        public void loadDriver()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select DriverID,DriverName from DriverDetails ";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            comboBox4.DataSource = dataSetObj.Tables[0];
            comboBox4.DisplayMember = "DriverName";
            comboBox4.ValueMember = "DriverID";
        }
    }
}
