using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public sealed class Employee : Person
    {
        

        public Employee( int designation, string nationalID, string firstName, string lastName, int gender, DateTime dateOfBirth, string contact, string email, string streetAddress, int postalCode, string city,byte[] photo) : base(firstName, lastName, gender, dateOfBirth, contact, email, streetAddress, postalCode, city)
        {
            this.Designation = designation;
            this.NID = nationalID;
            this.Photo = photo;
        }
        public int EmployeeID { get; set; }
        public int Designation { get; set; }
        public string NID { get; set; }
        public byte[] Photo { get; set; }
        
        Connection c = new Connection();

        public void InsertEmployee() 
        {
            
            c.con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c.con;
            cmd.CommandText = "EXEC spInsertEmployees @firstName,@lastName,@NID,@genderID,@designationID,@birthDate,@contact,@email,@streetAddress,@postalCode,@city,@photo";
            cmd.Parameters.AddWithValue("@firstName", FirstName);
            cmd.Parameters.AddWithValue("@lastName", LastName);
            cmd.Parameters.AddWithValue("@NID", NID);
            cmd.Parameters.AddWithValue("@genderID", Sex);
            cmd.Parameters.AddWithValue("@designationID", Designation);
            cmd.Parameters.AddWithValue("@birthDate", DateOfBirth);
            cmd.Parameters.AddWithValue("@contact", ContactNo);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@streetAddress", StreetAddress);
            cmd.Parameters.AddWithValue("@postalCode", PostalCode);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.Parameters.AddWithValue("@photo", Photo);
            cmd.ExecuteNonQuery();
            c.con.Close();

            MessageBox.Show("Data Inserted Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}
