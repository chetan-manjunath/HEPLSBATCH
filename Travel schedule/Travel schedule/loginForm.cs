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
using System.Configuration;

namespace Travel_schedule
{
    public partial class loginForm : Form
    {
        
        SqlConnection connectionObj;
        SqlDataAdapter dataAdapterObj, adapterObj1;
        SqlCommand selectCommand;
        SqlParameter parameterObj, parameterObj1;
        DataSet  dataSetObj;


        public loginForm()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            InitializeComponent();
            connectionObj = new SqlConnection(@connectionString);
            menuForm MenuObj = new menuForm();
            LoadUsernames();

        }
        private void LoadUsernames()
        {

            adapterObj1 = new SqlDataAdapter("select UserName from LoginCredentials", connectionObj);
            dataSetObj = new DataSet();
            adapterObj1.Fill(dataSetObj);

            comboBox1.DataSource = dataSetObj.Tables[0];
            comboBox1.DisplayMember = "UserName";
            comboBox1.ValueMember = "UserName";


        }

        private void Button1_Click(object sender, EventArgs e) // Login Button
        {
            menuForm MenuObj = new menuForm();
            
            try
            {
                
                validateLogin();
                this.Visible = false;
                DialogResult dr = MenuObj.ShowDialog(this);
                this.Visible = true;
            }
            catch(LoginFailureException s)
            {
                MessageBox.Show(s.Message);
            }
                
        }

        private void validateLogin()
        {
            dataAdapterObj = new SqlDataAdapter();
            selectCommand = new SqlCommand();
            parameterObj = new SqlParameter("@Password", textBox1.Text);
            selectCommand.Parameters.Add(parameterObj);

            parameterObj1 = new SqlParameter("@Username", comboBox1.SelectedValue.ToString());
            selectCommand.Parameters.Add(parameterObj1);

            connectionObj.Open();

            selectCommand.CommandText = "select count(UserName) from LoginCredentials where UserName=@Username and Password=@Password";
            selectCommand.Connection = connectionObj;
            dataAdapterObj.SelectCommand = selectCommand;

            dataSetObj = new DataSet();
            dataAdapterObj.Fill(dataSetObj);

            var LoginStatus = (int)dataSetObj.Tables[0].Rows[0][0];

            connectionObj.Close();
            if (LoginStatus <= 0)
            {
                throw new LoginFailureException("Incorrect Password... Please try again");
            }
            else
            {
                MessageBox.Show("Login Success");
            }
            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
