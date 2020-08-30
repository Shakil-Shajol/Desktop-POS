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
    public partial class frmPurchase : Form
    {
        public frmPurchase(int supplierID)
        {
            InitializeComponent();
            this.SuupID = supplierID;
        }
        Connection c = new Connection();
        public int SuupID { get; set; }
        public int CatID { get; private set; }
        public int ProID { get; private set; }
        public double NetPay { get; private set; }
        public double Discount { get; private set; }
        public double TotalAmount { get; private set; }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            string cmdtext = "SELECT supplierID,companyName FROM tblSuppliers WHERE supplierID="+SuupID;
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtSupplierID.Text = dt.Rows[0][0].ToString();
            txtSupplierName.Text=dt.Rows[0][1].ToString();
            TotalAmount = 0;
            NetPay = 0;
            Discount = 0;

            FillCombo();
        }

        private void FillCombo()
        {
            string cmdtext = "SELECT categoryID,categoryName FROM tblCategories";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbCategory.Items.Add(item);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbCategory.SelectedItem as ComboboxItem;
            CatID = Convert.ToInt32(selectedItem.Value);
            string cmdtext = "SELECT productID,productName FROM tblProducts WHERE catagoryID=" + CatID+"AND supplierID="+SuupID;
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
            string cmdtext = "SELECT purchasePrice FROM tblProducts WHERE productID=" + ProID;
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            txtUnitPrice.Text = Convert.ToDouble(dt.Rows[0][0]).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                var selectedItem = cmbProduct.SelectedItem as ComboboxItem;
                ProID = Convert.ToInt32(selectedItem.Value);
                string cmdtext = "SELECT productName,purchasePrice FROM tblProducts WHERE productID=" + ProID;
                SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);



                int pId = ProID;
                string pName = dt.Rows[0][0].ToString();
                int pQuantity = int.Parse(txtQuantity.Text);
                double unitPrice = Convert.ToDouble(dt.Rows[0][1]);
                double tamount = unitPrice * pQuantity;
                double discountRate = Convert.ToDouble(txtDiscount.Text)/100;

                

                dataGridView1.Rows.Add(dataGridView1.Rows.Count, pName, unitPrice, pQuantity, tamount, pId);
                TotalAmount += tamount;
                Discount = discountRate * TotalAmount;
                NetPay =TotalAmount-Discount;
                lblTotal.Text = TotalAmount.ToString();
                lblDiscount.Text = Discount.ToString();
                lblNetPay.Text = NetPay.ToString();
                ClearFields();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtQuantity.Clear();
            txtUnitPrice.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDiscount.Text = "0";
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            c.con.Open();
            double discountRate = Convert.ToDouble(txtDiscount.Text) / 100;
            SqlTransaction ts = c.con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.Transaction = ts;
                cmd.CommandText = "INSERT INTO tblPurchase(supplierID,purchaseDate,discountRate) VALUES (@supplierID, GETDATE(), @discountRate) select @@identity";
                cmd.Parameters.AddWithValue("@supplierID", SuupID);
                cmd.Parameters.AddWithValue("@discountRate", discountRate);
                int purchaseID = Convert.ToInt32(cmd.ExecuteScalar());

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = c.con;
                    cmd2.Transaction = ts;
                    cmd2.CommandText = "INSERT INTO tblPurchaseDetails(purchaseID,productID,quantity,price) VALUES (@purchaseID, @productID, @quantity, @price)";
                    cmd2.Parameters.AddWithValue("@purchaseID", purchaseID);
                    cmd2.Parameters.AddWithValue("@productID", dataGridView1.Rows[i].Cells["productID"].Value);
                    cmd2.Parameters.AddWithValue("@quantity", dataGridView1.Rows[i].Cells["quantity"].Value);
                    cmd2.Parameters.AddWithValue("@price", dataGridView1.Rows[i].Cells["unitPrice"].Value);
                    cmd2.ExecuteNonQuery();


                }
                ts.Commit();
                MessageBox.Show("Data Saved Successfully!!!!");
            }
            catch (Exception ex)
            {

                ts.Rollback();
                MessageBox.Show(ex.Message);
            }
            c.con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {

                    double discountRate = Convert.ToDouble(txtDiscount.Text) / 100;
                    int v = int.Parse(item.Cells[4].Value.ToString());
                    dataGridView1.Rows.RemoveAt(item.Index);
                    TotalAmount -= v;
                    Discount = discountRate * TotalAmount;
                    NetPay = TotalAmount - Discount;
                    lblTotal.Text = TotalAmount.ToString();
                    lblDiscount.Text = Discount.ToString();
                    lblNetPay.Text = NetPay.ToString();
                }
                
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
            }
            else
            {
                MessageBox.Show("Please select row to remove!", "Invalid", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
