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
    public partial class frmCustomerEntry : Form
    {
        public frmCustomerEntry()
        {
            InitializeComponent();
        }

        public string ContactNo { get; set; }
        public frmCustomerEntry(string contact)
        {
            InitializeComponent();
            this.ContactNo = contact;
        }
        private void btnCancel_Click(object sender, EventArgs e) => Hide();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int gid;
                if (rdMale.Checked == true)
                {
                    gid = 1;
                }
                else if (rdFemale.Checked == true)
                {
                    gid = 2;
                }
                else
                {
                    throw new Exception("You have to select Gender!");

                }
                Customer cus = new Customer(txtFirstName.Text, txtLastName.Text, gid, dtpDOB.Value, txtContact.Text, txtEmail.Text, txtStreetAddress.Text, int.Parse(txtPostalCode.Text), txtCity.Text);
                cus.InsertCustomer();
                ClearFrom();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void ClearFrom()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtStreetAddress.Clear();
            txtPostalCode.Clear();
            txtCity.Clear();
            dtpDOB.Value = DateTime.Now;
        }

        private void frmCustomerEntry_Load(object sender, EventArgs e)
        {
            txtContact.Text = ContactNo;
        }
    }
}
