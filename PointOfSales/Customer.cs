using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public sealed class Customer : Person
    {
        public Customer(int customerID,string firstName, string lastName, int gender, DateTime dateOfBirth, string contact, string email, string streetAddress, int postalCode, string city) : base(firstName, lastName, gender, dateOfBirth, contact, email, streetAddress, postalCode, city)
        {
            this.CustomerID = customerID;
        }
        public Customer(string firstName, string lastName, int gender, DateTime dateOfBirth, string contact, string email, string streetAddress, int postalCode, string city) : base(firstName, lastName, gender, dateOfBirth, contact, email, streetAddress, postalCode, city)
        {
            
        }



        public int CustomerID { get; set; }

        Connection c = new Connection();

        public void InsertCustomer()
        {

            c.con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c.con;
            cmd.CommandText = "EXEC spInsertCustomers @firstName,@lastName,@genderID,@birthDate,@contact,@email,@streetAddress,@postalCode,@city";
            cmd.Parameters.AddWithValue("@firstName", FirstName);
            cmd.Parameters.AddWithValue("@lastName", LastName);
            cmd.Parameters.AddWithValue("@genderID", Sex);
            cmd.Parameters.AddWithValue("@birthDate", DateOfBirth);
            cmd.Parameters.AddWithValue("@contact", ContactNo);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@streetAddress", StreetAddress);
            cmd.Parameters.AddWithValue("@postalCode", PostalCode);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.ExecuteNonQuery();
            c.con.Close();

            MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
