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
        int employeeID,TravelID;
        LocalTravelForm LocalObj;
        contorllerEdit ObjController;
        editmodel ModelObj;


        public editForm()
        {
            InitializeComponent();
            
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionObj = new SqlConnection(@connectionString);
            ObjController = new contorllerEdit();
            loadPlaces();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSetObj=ObjController.combo4(Convert.ToInt32(comboBox4.SelectedValue));
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dataSetObj = ObjController.GridViewClick(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            employeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            TravelID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            
            dataGridView1.DataSource = dataSetObj.Tables[0];
        }

        

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
       
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
            double date = dateTimePicker2.Value.Subtract(dateTimePicker1.Value).TotalDays;
            double date1 = dateTimePicker1.Value.Subtract(DateTime.Now).TotalDays;
            double date2 = dateTimePicker2.Value.Subtract(DateTime.Now).TotalDays;
            if (date > -1 && date1>-1 && date2>-1)
            {
                try
                {
                    ModelObj = new editmodel(dateTimePicker1.Value, dateTimePicker2.Value, TravelID);
                    ObjController.Update(ModelObj);
                    ComboBox4_SelectedIndexChanged(sender, e);
                }
                catch (Exception er) { MessageBox.Show("Select the employee first");
                    ComboBox4_SelectedIndexChanged(sender, e);
                }
                
            }
            else
            {
                if(date<0 || date2<0)
                    MessageBox.Show("Please select the correct departure date");
                else if(date1<0)
                    MessageBox.Show("Please select the correct arrival date");
                ComboBox4_SelectedIndexChanged(sender, e);
            }
           

        }

        public void loadPlaces()
        {
            dataSetObj = ObjController.Loadplace();

            comboBox4.DataSource = dataSetObj.Tables[0];
            comboBox4.DisplayMember = "PlaceName";
            comboBox4.ValueMember = "PlaceID";
        }

    }
}
