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
    public partial class frmSales : Form
    {
        
        Connection c = new Connection();
        public frmSales(int empid,int cusid)
        {
            InitializeComponent();
            this.EmpID = empid;
            this.CusID = cusid;
        }
        public int EmpID { get; set; }
        public int CusID { get; set; }
        public int CatID { get; set; }
        public int ProID { get; set; }
        public double NetPay { get; set; }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSales_Load(object sender, EventArgs e)
        {

            timerDate.Enabled = true;
            LoadEmployeeInfo();
            LoadCustomerInfo();

            FillCategoryCombo();
            NetPay = 0;
            lblNetPay.Text = NetPay.ToString();

        }

        private void FillCategoryCombo()
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

        private void LoadCustomerInfo()
        {
            string cmdtext2 = "SELECT firstName+' '+lastName,city FROM tblCustomers WHERE customerID =" + CusID;
            SqlDataAdapter sda2 = new SqlDataAdapter(cmdtext2, c.con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int rowcount2 = dt2.Rows.Count;
            if (rowcount2 == 1)
            {
                txtCustomerName.Text = dt2.Rows[0][0].ToString();
                textBox1.Text = dt2.Rows[0][1].ToString();
            }
            else if (rowcount2 == 0)
            {
                txtCustomerName.Text = "No Data Found!";
                textBox1.Text = "No Data Found!";
            }
        }

        private void LoadEmployeeInfo()
        {
            string cmdtext = "SELECT e.firstName+' '+e.lastName [Name] , d.designation FROM tblEmployees e JOIN tblDesignations d on d.designationID = e.designationID WHERE employeeID =" + EmpID;
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int rowcount = dt.Rows.Count;
            if (rowcount == 1)
            {
                lblEmployee.Text = dt.Rows[0][0].ToString() + ", Designation :" + dt.Rows[0][1].ToString();
            }
            else if (rowcount == 0)
            {
                lblEmplyeeInfo.Text = "No Data Found!";
            }
        }

        private void timerDate_Tick(object sender, EventArgs e)
        {
            DateTimeConverter dt = new DateTimeConverter();
            lblDate.Text =  dt.hhmmttddmmmmyyyy();
        }

        private void lblEmplyeeInfo_Click(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbProduct.SelectedItem as ComboboxItem;
            ProID = Convert.ToInt32(selectedItem.Value);
            string cmdtext = "SELECT p.retailPrice,p.discountRate,s.quantity FROM tblProducts p JOIN tblStock s ON p.ProductID=s.ProductID  WHERE p.productID=" + ProID;
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            txtUnitPrice.Text = Convert.ToDouble(dt.Rows[0][0]).ToString();
            txtDiscount.Text = (Convert.ToDouble(dt.Rows[0][1])*100).ToString()+"%";
            txtStock.Text = dt.Rows[0][2].ToString();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbCategory.SelectedItem as ComboboxItem;
            CatID = Convert.ToInt32(selectedItem.Value);
            string cmdtext = "SELECT productID,productName FROM tblProducts WHERE catagoryID="+CatID;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                var selectedItem = cmbProduct.SelectedItem as ComboboxItem;
                ProID = Convert.ToInt32(selectedItem.Value);
                string cmdtext = "SELECT p.productName,p.retailPrice,p.discountRate,s.quantity FROM tblProducts p JOIN tblStock s ON p.ProductID=s.ProductID  WHERE p.productID=" + ProID;
                SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);



                int pId = ProID;
                string pName = dt.Rows[0][0].ToString();
                int pQuantity = int.Parse(txtQuantity.Text);
                double unitPrice = Convert.ToDouble(dt.Rows[0][1]);
                double tamount = unitPrice * pQuantity;
                double discountRate = Convert.ToDouble(dt.Rows[0][2]);
                double discount = discountRate * tamount;
                double amount = tamount - discount;

                if (Convert.ToInt32(txtStock.Text)<pQuantity)
                {
                    throw new Exception("Insufficient Stock!");
                }

                dataGridView1.Rows.Add(dataGridView1.Rows.Count, pName, unitPrice, pQuantity, discount, amount, pId, discountRate);
                NetPay += amount;
                lblNetPay.Text = NetPay.ToString();
                ClearFields();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            

        }

        private void ClearFields()
        {
            txtQuantity.Clear();
            txtStock.Clear();
            txtUnitPrice.Clear();
            txtDiscount.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.con.Open();
            SqlTransaction ts = c.con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c.con;
                cmd.Transaction = ts;
                cmd.CommandText = "INSERT INTO tblSales(customerID,employeeID,salesDate) VALUES (@customerID, @employeeID, GETDATE()) select @@identity";
                cmd.Parameters.AddWithValue("@customerID", CusID);
                cmd.Parameters.AddWithValue("@employeeID", EmpID);
                int SalesID = Convert.ToInt32(cmd.ExecuteScalar());

                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = c.con;
                    cmd2.Transaction = ts;
                    cmd2.CommandText = "INSERT INTO tblSalesDetails(salesID,productID,quantity,price,discountRate) VALUES (@salesID, @productID, @quantity, @price, @discountRate)";
                    cmd2.Parameters.AddWithValue("@salesID", SalesID);
                    cmd2.Parameters.AddWithValue("@productID", dataGridView1.Rows[i].Cells["productID"].Value);
                    cmd2.Parameters.AddWithValue("@quantity", dataGridView1.Rows[i].Cells["quantity"].Value);
                    cmd2.Parameters.AddWithValue("@price", dataGridView1.Rows[i].Cells["unitPrice"].Value);
                    cmd2.Parameters.AddWithValue("@discountRate", dataGridView1.Rows[i].Cells["discountRate"].Value);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    int v=int.Parse(item.Cells[5].Value.ToString());
                    dataGridView1.Rows.RemoveAt(item.Index);
                    NetPay -= v;
                    lblNetPay.Text = NetPay.ToString();
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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
