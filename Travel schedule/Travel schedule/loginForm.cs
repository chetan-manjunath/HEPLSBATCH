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
            InitializeComponent();
            connectionObj = new SqlConnection(@"Data Source=BLR-PG00MPYX-L;Initial Catalog=Northwind;Integrated Security=True");

            dataAdapterObj = new SqlDataAdapter();
            selectCommand = new SqlCommand();

            LoadUsernames();

        }
        private void LoadUsernames()
        {

            adapterObj1 = new SqlDataAdapter("select Username from AdminCredentials", connectionObj);
            dataSetObj = new DataSet();
            adapterObj1.Fill(dataSetObj);

            comboBox1.DataSource = dataSetObj.Tables[0];
            comboBox1.DisplayMember = "Username";
            comboBox1.ValueMember = "UserName";


        }

        private void Button1_Click(object sender, EventArgs e) // Login Button
        {
           
            
            try
            {
                validateLogin();
            }
            catch(LoginFailureException s)
            {
                MessageBox.Show(s.Message);
            }
                
        }

        private void validateLogin()
        {
            parameterObj = new SqlParameter("@Password", textBox1.Text);
            selectCommand.Parameters.Add(parameterObj);

            parameterObj1 = new SqlParameter("@Username", comboBox1.SelectedValue.ToString());
            selectCommand.Parameters.Add(parameterObj1);

            connectionObj.Open();

            selectCommand.CommandText = "select count(Username) from AdminCredentials where Username=@Username and passwordd=@Password";
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
