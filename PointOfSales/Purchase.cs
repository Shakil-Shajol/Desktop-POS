using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public class Purchase
    {
        public Purchase(int purchaseID, int supplierID, DateTime purchaseDate, double grossPrice, float discount)
        {
            this.PurchaseID = purchaseID;
            this.SupplierID = supplierID;
            this.PurchaseDate = purchaseDate;
            this.GrossPrice = grossPrice;
            this.Discount = discount;
        }
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double GrossPrice { get; set; }
        public float Discount { get; set; }


        public string InsertToPurchase() 
        {
            string a = "EXEC spInsertPurchase "+SupplierID+","+Discount;
            return a;
        }
    }
}
