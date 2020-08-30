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
using System.IO;

namespace PointOfSales
{
    public partial class frmEmployeeEntry : Form
    {
        Connection c = new Connection();
        public frmEmployeeEntry()
        {
            InitializeComponent();
        }
        string loc = "";
        

        private void frmEmployeeEntry_Load(object sender, EventArgs e)
        {
            string cmdtext = "SELECT * FROM tblDesignations";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbDesignation.Items.Add(item);
            }
            
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            
            try
            {
                OpenFileDialog dia = new OpenFileDialog();
                dia.Filter = "jpg image(*.jpg)|*.jpg|png image(*.png)|*.png";

                if (dia.ShowDialog()==DialogResult.OK)
                {
                    loc = dia.FileName;

                    empImage.ImageLocation = loc;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int gid;
                int desigID;
                var selectedItem = cmbDesignation.SelectedItem as ComboboxItem;
                desigID =Convert.ToInt32(selectedItem.Value);
                byte[] img = null;
                FileInfo fi = new FileInfo(loc);
                long imlen = fi.Length;
                FileStream fs = new FileStream(loc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)imlen);

                if (rdMale.Checked == true)
                {
                    gid = 1;
                }
                else if(rdFemale.Checked==true)
                {
                    gid = 2;
                }
                else
                {
                    throw new Exception("You have to select Gender!");

                }

                if (txtNID.TextLength!=13)
                {
                    throw new Exception("NID number must be 13 charecter long!");
                }

                Employee emp = new Employee(desigID, txtNID.Text, txtFirstName.Text, txtLastName.Text, gid, dtpDOB.Value, txtContact.Text, txtEmail.Text, txtStreetAddress.Text, int.Parse(txtPostalCode.Text), txtCity.Text,img);
                emp.InsertEmployee();
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
            txtNID.Clear();
            txtEmail.Clear();
            txtStreetAddress.Clear();
            txtPostalCode.Clear();
            txtCity.Clear();
            cmbDesignation.SelectedIndex = -1;
            empImage.ImageLocation = null;
            dtpDOB.Value = DateTime.Now;
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFrom();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }

    public class ComboboxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }

        public override string ToString() { return Text; }
    }
}
