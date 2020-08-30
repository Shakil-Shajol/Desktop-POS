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
    public partial class frmTotalSalesReport : Form
    {
        Connection c = new Connection();
        public frmTotalSalesReport()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT E.employeeID,E.firstName+' '+E.lastName [Full Name],D.designation,G.gender,SUM(S.grossPrice) [Total Sales] FROM tblSales S JOIN tblEmployees E ON E.employeeID = S.employeeID JOIN tblGender G ON G.genderID = E.genderID JOIN tblDesignations D ON D.designationID = E.designationID WHERE S.salesDate BETWEEN @fromDate AND @toDate GROUP BY E.employeeID, E.firstName, E.lastName, D.designation, G.gender");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;
            cmd.Parameters.AddWithValue("@fromDate", dtpFromDate.Value);
            cmd.Parameters.AddWithValue("@toDate", dtpToDate.Value);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void frmTotalSalesReport_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT E.employeeID,E.firstName+' '+E.lastName [Full Name],D.designation,G.gender,SUM(S.grossPrice) [Total Sales] FROM tblSales S JOIN tblEmployees E ON E.employeeID = S.employeeID JOIN tblGender G ON G.genderID = E.genderID JOIN tblDesignations D ON D.designationID = E.designationID WHERE S.salesDate BETWEEN @fromDate AND @toDate GROUP BY E.employeeID, E.firstName, E.lastName, D.designation, G.gender");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;
            cmd.Parameters.AddWithValue("@fromDate", dtpFromDate.Value);
            cmd.Parameters.AddWithValue("@toDate", dtpToDate.Value);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            

        }
    }
}
