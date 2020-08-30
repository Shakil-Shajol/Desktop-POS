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
    
    public partial class frmEmployee : Form
    {
        Connection c = new Connection();
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT E.employeeID ID,E.firstName+' '+E.lastName [Name],D.designation Designation,G.gender Gender,E.contactNo Contact,E.email Email,E.empPhoto [Image] FROM tblEmployees E JOIN tblDesignations D ON D.designationID = E.designationID JOIN tblGender G ON G.genderID = E.genderID WHERE E.employeeID > 1");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c.con;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
