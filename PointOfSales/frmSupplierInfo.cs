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
    public partial class frmSupplierInfo : Form
    {
        public frmSupplierInfo()
        {
            InitializeComponent();
        }
        Connection c = new Connection();
        public int SuppID { get; set; }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedIndex >=0)
            {
                var selectedItem = cmbSupplier.SelectedItem as ComboboxItem;
                SuppID = Convert.ToInt32(selectedItem.Value);
                frmPurchase purchase = new frmPurchase(SuppID);
                purchase.MdiParent = this.MdiParent;
                purchase.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a supplier!", "Supplier not selected", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierEntry supEntry = new frmSupplierEntry();
            supEntry.MdiParent = this.MdiParent;
            supEntry.Show();
            Hide();
        }

        private void frmSupplierInfo_Load(object sender, EventArgs e)
        {
            string cmdtext = "SELECT supplierID,companyName FROM tblSuppliers";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbSupplier.Items.Add(item);
            }
        }
    }
}
