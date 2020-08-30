using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public sealed class Supplier : Contact
    {
        public Supplier(int supplierID,string companyName,string contactFirstname,string contactLastName,string fax,string contact, string email, string streetAddress, int postalCode, string city) : base(contact, email, streetAddress, postalCode, city)
        {
            this.SupplierID = supplierID;
            this.CompanyName = companyName;
            this.ContactFirstName = contactFirstname;
            this.ContactLastName = contactLastName;
            this.Fax = fax;
        }

        public Supplier( string companyName, string contactFirstname, string contactLastName,string fax, string contact, string email, string streetAddress, int postalCode, string city) : base(contact, email, streetAddress, postalCode, city)
        {
            this.CompanyName = companyName;
            this.ContactFirstName = contactFirstname;
            this.ContactLastName = contactLastName;
            this.Fax = fax;
        }

        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Fax { get; set; }
        
        Connection c = new Connection();


        public void InsertSupplier() 
        {
            c.con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c.con;
            cmd.CommandText = "EXEC spInsertSuppliers @company,@firstName,@lastName,@contact,@email,@fax,@streetAddress,@postalCode,@city";
            cmd.Parameters.AddWithValue("@company", CompanyName);
            cmd.Parameters.AddWithValue("@firstName", ContactFirstName);
            cmd.Parameters.AddWithValue("@lastName", ContactLastName);
            cmd.Parameters.AddWithValue("@contact", ContactNo);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@fax", Fax);
            cmd.Parameters.AddWithValue("@streetAddress", StreetAddress);
            cmd.Parameters.AddWithValue("@postalCode", PostalCode);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.ExecuteNonQuery();
            c.con.Close();

            MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
