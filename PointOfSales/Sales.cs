using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public class Sales
    {
        public Sales(int salesID,int customerID,int employeeID,DateTime salesDate,double grossPrice,double discount)
        {
            this.SalesID = salesID;
            this.CustomerID = customerID;
            this.EmployeeID = employeeID;
            this.SalesDate = salesDate;
            this.GrossPrice = grossPrice;
            this.Discount = discount;
        }
        public int SalesID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime SalesDate { get; set; }
        public double GrossPrice { get; set; }
        public double Discount { get; set; }
        





        //salesID INT IDENTITY(1000001,1) PRIMARY KEY,
        //customerID INT REFERENCES customers(customerID),
        //employeeID INT REFERENCES employees(employeeID),
        //salesDate DATETIME DEFAULT GETDATE(),
        //grossPrice MONEY,
        //discount MONEY,
        //netPay AS grossPrice-discount
    }
}
