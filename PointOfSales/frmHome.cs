using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public partial class frmHome : Form
    {
        public frmHome(int empid)
        {
            InitializeComponent();
            this.EmpID = empid;
        }

        public int EmpID { get; set; }


        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerInfo cusInfo = new frmCustomerInfo(EmpID);
            cusInfo.MdiParent = this;
            cusInfo.Show();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }


        

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerEntry cusEntry = new frmCustomerEntry();
            cusEntry.MdiParent = this;
            cusEntry.Show();
        }

        

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword cp = new frmChangePassword(EmpID);
            cp.MdiParent = this;
            cp.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts p = new frmProducts();
            p.MdiParent = this;
            p.Show();
        }

        private void mySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMySaleReport m = new frmMySaleReport(EmpID);
            m.MdiParent = this;
            m.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogIn l = new frmLogIn();
            l.Show();
            this.Close();
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
