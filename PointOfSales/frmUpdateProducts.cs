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
    public partial class frmUpdateProducts : Form
    {
       
        Connection c = new Connection();

        public int CatID { get; private set; }
        public int ProID { get; private set; }

        public frmUpdateProducts()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.CommandText = "UPDATE tblProducts SET productName= @productName, size=@size,sizeUnit=@sizeUnit,purchasePrice=@purchasePrice,retailPrice= @retailPrice,discountRate= @discountRate,note= @note WHERE productID=" + ProID;
                cmd.Parameters.AddWithValue("@productName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@size", txtSize.Text);
                cmd.Parameters.AddWithValue("@sizeUnit", cmbSizeUnit.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@purchasePrice", txtPurchasePrice.Text);
                cmd.Parameters.AddWithValue("@retailPrice", txtSalePrice.Text);
                cmd.Parameters.AddWithValue("@discountRate", Convert.ToDouble(txtDiscount.Text) / 100);
                cmd.Parameters.AddWithValue("@note", txtFileUrl.Text);
                cmd.ExecuteNonQuery();
                c.con.Close();
                MessageBox.Show("Producet Updated Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtSearchID.Clear();
            txtProductName.Clear();
            txtSize.Clear();
            txtFileUrl.Clear();
            txtPurchasePrice.Clear();
            txtSalePrice.Clear();
            txtDiscount.Clear();
            cmbSizeUnit.SelectedIndex = -1;
            imgProduct.Image = null;
            txtSearchID.Focus();

        }
        

        

        private void LoadSelCmbCat()
        {
            string cmdtext = "SELECT * FROM tblCategories";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbSelectCategory.Items.Add(item);

            }
        }

        private void frmUpdateProducts_Load(object sender, EventArgs e)
        {
            
            LoadSelCmbCat();
            txtSearchID.Focus();
        }

        private void cmbSelectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbSelectCategory.SelectedItem as ComboboxItem;
            CatID = Convert.ToInt32(selectedItem.Value);
            string cmdtext = "SELECT productID,productName FROM tblProducts WHERE catagoryID=" + CatID;
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbProduct.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbProduct.Items.Add(item);
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbProduct.SelectedItem as ComboboxItem;
            ProID = Convert.ToInt32(selectedItem.Value);
            LoadsFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProID = Convert.ToInt32(txtSearchID.Text);
            
            LoadsFields();
        }

        private void LoadsFields()
        {
            string cmdtext = "SELECT * FROM tblProducts  WHERE productID=" + ProID;
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtID.Text = Convert.ToDouble(dt.Rows[0][0]).ToString();
            txtDiscount.Text = (Convert.ToDouble(dt.Rows[0][8]) * 100).ToString();
            txtProductName.Text = dt.Rows[0][1].ToString();
            txtPurchasePrice.Text = dt.Rows[0][6].ToString();
            txtSalePrice.Text = dt.Rows[0][7].ToString();
            txtSize.Text = dt.Rows[0][4].ToString();
            txtFileUrl.Text = dt.Rows[0][9].ToString();
            cmbSizeUnit.SelectedItem = dt.Rows[0][5].ToString();
            byte[] img = (byte[])dt.Rows[0][10];
            if (img == null)
            {
                imgProduct.Image = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream(img);
                imgProduct.Image = Image.FromStream(ms);
            }
        }
    }
}
