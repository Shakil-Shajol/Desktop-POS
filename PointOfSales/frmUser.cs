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
    public partial class frmUser : Form
    {
        Connection c = new Connection();
        public frmUser()
        {
            InitializeComponent();
        }

        

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                c.con.Open();
                try
                {
                    if (txtPassword.Text == txtConfirmPassword.Text)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = c.con;
                        cmd.CommandText = "INSERT INTO tblLogin VALUES(@empid,@username,@password)";
                        cmd.Parameters.AddWithValue("@empid", Convert.ToInt32(txtEmpID.Text));
                        cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"User created Successfully!\nUser : {txtUserName.Text}\nPassword:{txtPassword.Text}", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Password Doesn't match", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                c.con.Close();
            }
            else
            {
                MessageBox.Show("User Name or Password field is epmty!\nPlease fill the field(s)", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtName.Clear();
            txtNID.Clear();
            txtDesignation.Clear(); 
            empImage.Image = null;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            string cmdtext = "SELECT employeeID, firstName FROM tblEmployees WHERE employeeID NOT IN (SELECT employeeID FROM tblLogin)";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbEmployeeID.Items.Add(item);
            }
        }

        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = cmbEmployeeID.SelectedItem as ComboboxItem;
                int empid = Convert.ToInt32(selectedItem.Value);
                string cmdtext = "SELECT E.firstName+' '+E.lastName, D.designation,E.nationalIDNo,E.empPhoto FROM tblEmployees E JOIN tblDesignations D ON D.designationID=E.designationID WHERE E.employeeID=" + empid;
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
                }
                else
                {
                    txtName.Text = "";
                    txtDesignation.Text = "";
                    txtNID.Text = "";
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
