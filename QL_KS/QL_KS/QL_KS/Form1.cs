using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace QL_KS
{
    public partial class Form1 : Form
    {
        Connect con = new Connect();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string s = "select username,pass from NHANSU WHERE username = '"+txtUserName.Text+"' and pass = '"+txtpass.Text+"'";
            DataTable dt = con.Execute(s);
            if(dt.Rows.Count > 0)
            {
                lblerorr.Visible = false;
                Dash dash = new Dash();
                this.Hide();
                dash.Show();
            }
            else
            {
                lblerorr.Visible = true;
                txtpass.Focus();
            }
        }
    }
}
