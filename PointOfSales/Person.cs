using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public abstract class Person:Contact
    {
        public Person(string firstName, string lastName,int gender,DateTime dateOfBirth,string contact,string email,string streetAddress,int postalCode,string city):base(contact,email,streetAddress,postalCode,city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Sex = gender;
            this.DateOfBirth = dateOfBirth;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Sex { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
