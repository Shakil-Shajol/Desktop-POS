using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public class Category
    {
        public Category(int categoryID,string categoryName,string categoryDescription)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.CategoryDescription = categoryDescription;
        }

        public Category(string categoryName, string categoryDescription)
        {
            this.CategoryName = categoryName;
            this.CategoryDescription = categoryDescription;
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        Connection c = new Connection();
        public void InsertCategory()
        {
            c.con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c.con;
            cmd.CommandText = "EXEC spInsertCategories @categoryName, @categoryDescription";
            cmd.Parameters.AddWithValue("@categoryName", CategoryName);
            cmd.Parameters.AddWithValue("@categoryDescription", CategoryDescription);
            cmd.ExecuteNonQuery();
            c.con.Close();

            MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

                                           
    }
}
