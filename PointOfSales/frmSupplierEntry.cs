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
    public partial class frmSupplierEntry : Form
    {
        public frmSupplierEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier supplier = new Supplier(txtCompanyName.Text, txtFirstName.Text, txtLastName.Text, txtFax.Text, txtContact.Text, txtEmail.Text, txtStreetAddress.Text, Convert.ToInt32(txtPostalCode.Text), txtCity.Text);
                supplier.InsertSupplier();
                ClearForm();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void ClearForm()
        {
            txtCompanyName.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFax.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            txtStreetAddress.Clear();
            txtPostalCode.Clear();
            txtCity.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
