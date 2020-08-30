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

namespace PointOfSales
{
    public partial class frmLogIn : Form
    {
        
        int empid;
        Connection c = new Connection();
        
        public frmLogIn()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdtext = "SELECT * FROM tblLogin WHERE userName='"+txtUsername.Text+"' AND empPassword='"+txtPassword.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int rowcount = dt.Rows.Count;

            

            if (rowcount==1)
            {
                empid = Convert.ToInt32(dt.Rows[0][0]);
                string cmdtext2 = "SELECT employeeID,designationID FROM tblEmployees WHERE employeeID=" +empid;
                SqlDataAdapter sda2 = new SqlDataAdapter(cmdtext2, c.con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int desID = Convert.ToInt32(dt2.Rows[0][1]);
                if (desID == 1 || desID == 2)
                {
                    frmHome_Admin admin = new frmHome_Admin(empid);
                    this.Hide();
                    admin.Show();
                }
                else
                {
                    frmHome ho = new frmHome(empid);
                    this.Hide();
                    ho.Show();
                }

            }
            else
            {
                MessageBox.Show("Username and password doesnot match!", "Password Incorect", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "123456";
        }

        private void frmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
