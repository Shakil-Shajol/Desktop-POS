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

namespace PointOfSales
{
    public partial class frmCustomerInfo : Form
    {
        public frmCustomerInfo(int empid)
        {
            InitializeComponent();
            this.EmpID=empid;
        }
        public int EmpID { get; set; }
        public int CusID { get; set; }
        Connection c = new Connection();
        private void btnProcedSales_Click(object sender, EventArgs e)
        {
            frmSales sales = new frmSales(EmpID, CusID);
            sales.MdiParent = this.MdiParent;
            this.Hide();
            sales.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdtext2 = "SELECT customerID,firstName+' '+lastName,contactNo,streetAddress,postalCode,city FROM tblCustomers WHERE contactNo ='" + txtContact.Text+"'";
            SqlDataAdapter sda2 = new SqlDataAdapter(cmdtext2, c.con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int rowcount2 = dt2.Rows.Count;
            if (rowcount2 == 1)
            {
                grpCustomerInfo.Visible = true;

                grpNodataFound.Visible = false;
                txtName.Text = dt2.Rows[0][1].ToString();
                txtContactGrp.Text = dt2.Rows[0][2].ToString();
                txtAddress.Text = dt2.Rows[0][3].ToString() + Environment.NewLine + dt2.Rows[0][5].ToString()+"-"+ dt2.Rows[0][4].ToString();
                this.CusID = Convert.ToInt32(dt2.Rows[0][0]);
            }
            else if (rowcount2 == 0)
            {
                grpNodataFound.Visible = true;
                grpCustomerInfo.Visible = false;
            }
            else
            {
                throw new Exception();
            }
            
            
        }

        private void btnCustomerEntry_Click(object sender, EventArgs e)
        {
            frmCustomerEntry cusEntry = new frmCustomerEntry(txtContact.Text);
            cusEntry.MdiParent = this.MdiParent;
            this.Hide();
            cusEntry.Show();
        }
    }
}
