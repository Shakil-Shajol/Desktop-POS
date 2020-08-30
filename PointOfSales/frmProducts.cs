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
    public partial class frmProducts : Form
    {
        Connection c = new Connection();
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT P.productName,C.categoryName,S.companyName,CONVERT(VARCHAR, P.size) + ' ' + P.sizeUnit  [Size],P.retailPrice,P.discountRate,P.productImage FROM tblProducts P JOIN tblCategories C ON C.categoryID = P.catagoryID JOIN tblSuppliers S ON S.supplierID = P.supplierID");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;



            
        }
    }
}
