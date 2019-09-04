using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel_schedule
{
    public partial class menuForm : Form
    {
        AddForm AddObj;
        viewForm ViewObj;
        editForm EditObj;
        public menuForm()
        {
            InitializeComponent();
            AddObj = new AddForm();
            ViewObj = new viewForm();
            EditObj = new editForm();
        }

        private void Button1Add_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            DialogResult Adddr = AddObj.ShowDialog(this);
            this.Visible = true;

        }

        private void Button2View_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DialogResult viewdr =ViewObj.ShowDialog(this);
            this.Visible = true;
        }

        private void Button3Edit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DialogResult editdr = EditObj.ShowDialog(this);
            this.Visible = true;
        }

        private void Button4SignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
