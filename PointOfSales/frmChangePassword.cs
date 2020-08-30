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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int empID)
        {
            InitializeComponent();
            this.EmpID = empID;
        }
        Connection c = new Connection();
        private string loc;

        public int EmpID { get; set; }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdtext = "SELECT * FROM tblLogin  WHERE employeeID=" + EmpID;
                SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                string currpass = dt.Rows[0][2].ToString();
                if (txtCurrentPass.Text == currpass && txtPassword.Text == txtConfirmPassword.Text)
                {
                    c.con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = c.con;
                    cmd.CommandText = "UPDATE tblLogin SET empPassword='" + txtConfirmPassword.Text + "' WHERE employeeID=" + EmpID;
                    cmd.ExecuteNonQuery();
                    c.con.Close();

                    MessageBox.Show("Password changed Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Password doesn't match!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                string cmdtext = "SELECT E.firstName+' '+E.lastName, D.designation,E.nationalIDNo,E.empPhoto,l.userName FROM tblEmployees E JOIN tblDesignations D ON D.designationID=E.designationID JOIN tblLogin l ON l.employeeID=E.employeeID WHERE E.employeeID=" + EmpID;
                SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                txtUser.Focus();
                int rowcount = dt.Rows.Count;
                if (rowcount == 1)
                {
                    txtUser.Text = dt.Rows[0][4].ToString();
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
            catch (Exception)
            {

            }
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Photo = null;
                FileInfo fi = new FileInfo(loc);
                long imlen = fi.Length;
                FileStream fs = new FileStream(loc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Photo = br.ReadBytes((int)imlen);

                c.con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "UPDATE tblEmployees SET empPhoto=@photo WHERE employeeID=@employeeID";
                cmd.Parameters.AddWithValue("@employeeID", EmpID);
                cmd.Parameters.AddWithValue("@photo", Photo);
                cmd.ExecuteNonQuery();
                c.con.Close();

                MessageBox.Show("Image Updated Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dia = new OpenFileDialog();
                dia.Filter = "jpg image(*.jpg)|*.jpg|png image(*.png)|*.png";

                if (dia.ShowDialog() == DialogResult.OK)
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
    }
}
