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
            double date1 = dateTimePicker2.Value.Subtract(DateTime.Now).TotalDays;
            if (date1 > -1)
            {
                try
                {
                    sqlDataAdapterObj = new SqlDataAdapter();
                    updateCommandObj = new SqlCommand();
                    updateCommandObj.CommandText = "update LocalSchedule set Date=@depatureDate where SerialNumber=@TravelID";
                    updateCommandObj.Connection = sqlConnectionObj;
                    sqlParameterObj1 = new SqlParameter("@depatureDate", Convert.ToDateTime(dateTimePicker2.Value));
                    sqlParameterObj = new SqlParameter("@TravelID", SerialNumber);
                    updateCommandObj.Parameters.Add(sqlParameterObj);
                    updateCommandObj.Parameters.Add(sqlParameterObj1);
                    sqlDataAdapterObj.SelectCommand = updateCommandObj;
                    sqlConnectionObj.Open();
                    updateCommandObj.ExecuteNonQuery();
                    //ComboBox2_SelectedIndexChanged(sender, e);

                }
                catch (Exception er)
                {
                    MessageBox.Show("catch block is executed");
                    //ComboBox4_SelectedIndexChanged(sender, e);
                }
                finally
                {
                    sqlConnectionObj.Close();
                    Scheduledetails(TravelID);
                }
            }
            else 
            { 
                    MessageBox.Show("Please select the correct date");
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            SerialNumber= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            loadToLocation();
            loadFromLocation();
            
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
                placeToValidation();

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
                placeFromValidation();
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
            selectCommandObj.CommandText = "SELECT LocalSchedule.SerialNumber,LocalSchedule.TravelID,LocalSchedule.Date,Status.State as Travel_State,l.Place as destination ,l1.Place as source,LocalSchedule.DriverID from LocalSchedule,LocalTravelOptions l, LocalTravelOptions l1 ,Status where l.LocationID = LocalSchedule.FromLocalLocationID and l1.LocationID = LocalSchedule.ToLocalLocationID and LocalSchedule.TravelID = @Id and LocalSchedule.StatusID = Status.StatusID";
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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        public void placeFromValidation()
        {
            try
            {
                sqlDataAdapterObj = new SqlDataAdapter();
                selectCommandObj = new SqlCommand();
                selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions where @Id != LocationID ";
                sqlParameterObj = new SqlParameter("@Id", comboBox1.SelectedValue);
                selectCommandObj.Parameters.Add(sqlParameterObj);
                selectCommandObj.Connection = sqlConnectionObj;
                sqlDataAdapterObj.SelectCommand = selectCommandObj;
                dataSetObj = new DataSet();
                sqlDataAdapterObj.Fill(dataSetObj);
                comboBox2.DataSource = dataSetObj.Tables[0];
                comboBox2.DisplayMember = "Place";
                comboBox2.ValueMember = "LocationID";
            }
            catch(Exception e) { }
        }
        public void placeToValidation()
        {
            try
            {
                sqlDataAdapterObj = new SqlDataAdapter();
                selectCommandObj = new SqlCommand();
                selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions where @Id != LocationID ";
                sqlParameterObj = new SqlParameter("@Id", comboBox2.SelectedValue);
                selectCommandObj.Parameters.Add(sqlParameterObj);
                selectCommandObj.Connection = sqlConnectionObj;
                sqlDataAdapterObj.SelectCommand = selectCommandObj;
                dataSetObj = new DataSet();
                sqlDataAdapterObj.Fill(dataSetObj);
                comboBox1.DataSource = dataSetObj.Tables[0];
                comboBox1.DisplayMember = "Place";
                comboBox1.ValueMember = "LocationID";
            }
            catch (Exception e) { }
        }
    }
}
