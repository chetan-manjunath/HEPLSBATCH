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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Travel_schedule
{
    public partial class loginForm : Form
    {
        
        SqlConnection connectionObj;
        SqlDataAdapter dataAdapterObj, adapterObj1;
        SqlCommand selectCommand;
        SqlParameter parameterObj, parameterObj1;
        DataSet  dataSetObj1;
        controllerlogin ObjLogin;

        public loginForm()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            InitializeComponent();
            connectionObj = new SqlConnection(@connectionString);
            menuForm MenuObj = new menuForm();
            textBox1.PasswordChar = '*';
            ObjLogin = new controllerlogin();
            LoadUsernames();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void LoadUsernames()
        {

            dataSetObj1 = ObjLogin.LoadUsernames();
            
            comboBox1.DataSource = dataSetObj1.Tables[0];
            
            comboBox1.DisplayMember = "UserName";
            comboBox1.ValueMember = "UserName";


        }

        private void Button1_Click(object sender, EventArgs e) // Login Button
        {
            menuForm MenuObj = new menuForm();
            
            try
            {
                loginModel LoginObj = new loginModel(comboBox1.SelectedValue.ToString(), textBox1.Text);
                ObjLogin.validateLogin(LoginObj);
                textBox1.Text = "";
                this.Visible = false;
                DialogResult dr = MenuObj.ShowDialog(this);
                this.Visible = true;
            }
            catch(LoginFailureException s)
            {
                MessageBox.Show(s.Message);
            }
                
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
