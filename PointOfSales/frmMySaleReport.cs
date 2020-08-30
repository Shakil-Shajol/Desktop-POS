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
    public partial class frmMySaleReport : Form
    {
        Connection c = new Connection();
        public frmMySaleReport()
        {
            InitializeComponent();
        }
        public frmMySaleReport(int empId)
        {
            InitializeComponent();
            this.EmpID = empId;
        }
        public int EmpID { get; set; }

        private void frmMySaleReport_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT CONVERT(VARCHAR,S.salesDate,23) Date,SUM(S.grossPrice) [Total Sales] FROM tblSales S JOIN tblEmployees E ON E.employeeID = S.employeeID WHERE S.employeeID=@employee AND S.salesDate BETWEEN @fromDate AND @toDate GROUP BY S.salesDate");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;
            cmd.Parameters.AddWithValue("@fromDate", dtpFromDate.Value);
            cmd.Parameters.AddWithValue("@toDate", dtpToDate.Value);
            cmd.Parameters.AddWithValue("@employee", EmpID);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
