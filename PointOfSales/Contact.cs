using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public abstract class Contact
    {
        
        public Contact(string contact,string email, string streetAddress, int postalCode, string city)
        {
            this.ContactNo = contact;
            this.Email = email;
            this.StreetAddress = streetAddress;
            this.PostalCode = postalCode;
            this.City = city;

        }
        private string _contactNo;
        private string _email;
        private string _streetAddress;
        private int _postalCode;
        private string _city;

        public string ContactNo { get => this._contactNo; set => this._contactNo=value; }
        public string Email { get => this._email; set=>this._email=value; }
        public string StreetAddress { get=>this._streetAddress; set=>this._streetAddress=value; }
        public int PostalCode { get=>this._postalCode; set=>this._postalCode=value; }
        public string City { get=>this._city; set=>this._city=value; }
    }
}
