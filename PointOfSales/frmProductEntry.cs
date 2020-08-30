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
    public partial class frmProductEntry : Form
    {
        private string loc;
        Connection c = new Connection();

        public frmProductEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int suppID;
                var selectedSupplier = cmbSupplier.SelectedItem as ComboboxItem;
                suppID = Convert.ToInt32(selectedSupplier.Value);

                int catID;
                var selectedCat = cmbCategory.SelectedItem as ComboboxItem;
                catID = Convert.ToInt32(selectedCat.Value);

                string sizeunit = cmbSizeUnit.SelectedItem.ToString();

                byte[] img = null;
                FileInfo fi = new FileInfo(loc);
                long imlen = fi.Length;
                FileStream fs = new FileStream(loc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)imlen);
                double discountRate = Convert.ToDouble(txtDiscount.Text) / 100;

                Product p = new Product(txtProductName.Text, catID, suppID, int.Parse(txtSize.Text), sizeunit, Convert.ToDouble(txtPurchasePrice.Text), Convert.ToDouble(txtSalePrice.Text), discountRate, txtFileUrl.Text, 0, "pices", img);

                p.InsertProduct();
                ClearForm();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            txtSize.Clear();
            txtFileUrl.Clear();
            txtPurchasePrice.Clear();
            txtSalePrice.Clear();
            txtDiscount.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbSizeUnit.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

                    imgProduct.ImageLocation = loc;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        

        private void frmProductEntry_Load(object sender, EventArgs e)
        {
            LoadCmbCat();
            LoadCmbSupp();
        }

        private void LoadCmbSupp()
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

        private void LoadCmbCat()
        {
            string cmdtext = "SELECT * FROM tblCategories";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbCategory.Items.Add(item);

            }
        }
    }
}
