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
    public partial class frmHome_Admin : Form
    {
        public int EmpID { get; }

        public frmHome_Admin(int empid)
        {
            InitializeComponent();
            this.EmpID = empid;
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser user = new frmUser();
            user.MdiParent = this;
            user.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeEntry ement = new frmEmployeeEntry();
            ement.MdiParent = this;
            ement.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerEntry cusEntry = new frmCustomerEntry();
            cusEntry.MdiParent = this;
            cusEntry.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierEntry supEntry = new frmSupplierEntry();
            supEntry.MdiParent = this;
            supEntry.Show();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductEntry pent = new frmProductEntry();
            pent.MdiParent = this;
            pent.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryEntry categoryEntry = new frmCategoryEntry();
            categoryEntry.MdiParent = this;
            categoryEntry.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierInfo suppli = new frmSupplierInfo();
            suppli.MdiParent = this;
            suppli.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerInfo cusInfo = new frmCustomerInfo(EmpID);
            cusInfo.MdiParent = this;
            cusInfo.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword cp = new frmChangePassword(EmpID);
            
            cp.MdiParent = this;
            cp.Show();
            

        }

        private void totalSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTotalSalesReport totalSR = new frmTotalSalesReport();
            totalSR.MdiParent = this;
            totalSR.Show();
        }

        private void employeeWiseSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeWiseSales esr = new frmEmployeeWiseSales();
            esr.MdiParent = this;
            esr.Show();
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProducts p = new frmProducts();
            p.MdiParent = this;
            p.Show();
        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmployee emp = new frmEmployee();
            emp.MdiParent = this;
            emp.Show();
        }

        private void updatePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateProducts p = new frmUpdateProducts();
            p.MdiParent = this;
            p.Show();
        }

        private void updateUserAcountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUserAccount p = new frmUpdateUserAccount();
            p.MdiParent = this;
            p.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogIn l = new frmLogIn();
            l.Show();
            this.Close();
        }

        

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReport sr = new frmStockReport();
            sr.MdiParent = this;
            sr.Show();
        }

        private void frmHome_Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
