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
        controllerLocalschedule ControllerObj;
        public LocalTravelForm(int id)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionObj = new SqlConnection(@connectionString);
            ControllerObj = new controllerLocalschedule();
            Scheduledetails(id);
            TravelID = id;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            double date1 = dateTimePicker2.Value.Subtract(DateTime.Now).TotalDays;
            if (date1 > -1)
            {
                try
                {

                    ControllerObj.DateTimeClick(TravelID,dateTimePicker2.Value);
                    

                }
                catch (Exception er)
                {
                    MessageBox.Show("Invalid date");
                    
                }
                finally
                {
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
                ControllerObj.Button4Click(toLocation,SerialNumber);
                placeToValidation();

            }
            catch (Exception ex) { }
            finally
            {
                sqlConnectionObj.Close();
                dataGridView1.Refresh();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                int driverID = Convert.ToInt32(comboBox4.SelectedValue);
                ControllerObj.Button5Click(driverID, SerialNumber);
            }
            catch (Exception ex) { }
            finally
            {
                dataGridView1.Refresh();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int fromLocation = Convert.ToInt32(comboBox1.SelectedValue);
                ControllerObj.Button1Click(fromLocation, SerialNumber);
                placeFromValidation();
            }
            catch (Exception ex) { }
            finally
            {
                Scheduledetails(TravelID);
                dataGridView1.Refresh();
            }
            
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int StatusID = Convert.ToInt32(comboBox3.SelectedValue);
                ControllerObj.Button2Click(StatusID, SerialNumber);
            }
            catch (Exception ex) { }
            finally
            {
                
                dataGridView1.Refresh();
            }
        }

        public void Scheduledetails(int id)
        {
            dataSetObj = ControllerObj.Scheduledetails(id);
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }
        public void loadFromLocation()
        {
            dataSetObj = ControllerObj.loadFromLocation();
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
            dataSetObj = ControllerObj.loadToLocation();
            comboBox2.DataSource = dataSetObj.Tables[0];
            comboBox2.DisplayMember = "Place";
            comboBox2.ValueMember = "LocationID";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void loadStatus()
        {
            dataSetObj = ControllerObj.loadStatus();
            comboBox3.DataSource = dataSetObj.Tables[0];
            comboBox3.DisplayMember = "State";
            comboBox3.ValueMember = "StatusID";
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void loadDriver()
        {
            dataSetObj = ControllerObj.loadDriver();

            comboBox4.DataSource = dataSetObj.Tables[0];
            comboBox4.DisplayMember = "DriverName";
            comboBox4.ValueMember = "DriverID";
        }

        public void placeFromValidation()
        {
            try
            {
                
                dataSetObj = ControllerObj.placeFromValidation(Convert.ToInt32(comboBox1.SelectedValue));
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
                dataSetObj = ControllerObj.placeToValidation(Convert.ToInt32(comboBox2.SelectedValue));
                comboBox1.DataSource = dataSetObj.Tables[0];
                comboBox1.DisplayMember = "Place";
                comboBox1.ValueMember = "LocationID";
            }
            catch (Exception e) { }
        }
    }
}
