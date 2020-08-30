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
    public partial class frmEmployeeWiseSales : Form
    {
        Connection c = new Connection();
        public frmEmployeeWiseSales()
        {
            InitializeComponent();
        }

        private void frmEmployeeWiseSales_Load(object sender, EventArgs e)
        {
            string cmdtext = "SELECT * FROM tblEmployees";
            SqlDataAdapter sda = new SqlDataAdapter(cmdtext, c.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var item = new ComboboxItem { Value = dt.Rows[i][0], Text = Convert.ToString(dt.Rows[i][1]) };
                cmbEmployee.Items.Add(item);

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = cmbEmployee.SelectedItem as ComboboxItem;
                int EmpID = 0;
                EmpID = Convert.ToInt32(selectedItem.Value);
                if (EmpID==0)
                {
                    throw new Exception("Please select employee!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT CONVERT(VARCHAR,S.salesDate,23) [Date],c.firstName+' '+c.lastName [Customer],SUM(S.grossPrice) [Total Sales] FROM tblSales S JOIN tblCustomers c ON c.customerID = S.customerID WHERE S.employeeID = @Employee AND S.salesDate BETWEEN @fromDate AND @toDate GROUP BY S.salesDate, c.firstName, c.lastName");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = c.con;
                    cmd.Parameters.AddWithValue("@fromDate", dtpFromDate.Value);
                    cmd.Parameters.AddWithValue("@toDate", dtpToDate.Value);
                    cmd.Parameters.AddWithValue("@Employee", EmpID);


                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }
    }
}
