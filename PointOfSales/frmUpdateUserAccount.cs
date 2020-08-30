using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public partial class frmUpdateUserAccount : Form
    {
        Connection c = new Connection();
        public frmUpdateUserAccount()
        {
            InitializeComponent();
        }

        private void frmUpdateUserAccount_Load(object sender, EventArgs e)
        {
            string cmdtext = "SELECT employeeID, firstName FROM tblEmployees WHERE employeeID IN (SELECT employeeID FROM tblLogin)";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbEmployeeID.Items.Add(item);
            }
        }

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtEmpID.Clear();
            txtUserName.Clear();
            txtName.Clear();
            txtNID.Clear();
            txtDesignation.Clear();
            empImage.Image = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "DELETE tblLogin WHERE employeeID="+txtEmpID.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show($"User Removed Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                c.con.Close();
                
            }
        }

        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = cmbEmployeeID.SelectedItem as ComboboxItem;
                int empid = Convert.ToInt32(selectedItem.Value);
                string cmdtext = "SELECT E.firstName+' '+E.lastName, D.designation,E.nationalIDNo,E.empPhoto, L.userName FROM tblEmployees E JOIN tblDesignations D ON D.designationID=E.designationID JOIN tblLogin L ON E.employeeID=L.employeeID WHERE E.employeeID=" + empid;
                SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    txtEmpID.Text = empid.ToString();
                    txtName.Text = dt.Rows[0][0].ToString();
                    txtDesignation.Text = dt.Rows[0][1].ToString();
                    txtNID.Text = dt.Rows[0][2].ToString();
                    byte[] img = (byte[])dt.Rows[0][3];
                    if (img == null)
                    {
                        empImage.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        empImage.Image = Image.FromStream(ms);
                    }
                    txtUserName.Text = dt.Rows[0][4].ToString();
                }
                else
                {
                    txtEmpID.Text = "";
                    txtName.Text = "";
                    txtDesignation.Text = "";
                    txtNID.Text = "";
                    txtUserName.Text = "";
                    empImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
    }
}
