using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public class Product
    {
        Connection c = new Connection();
        public Product(int productID,string productName,int categoryID,int supplierID,int size,string sizeUnit, double purchasePrice,double retailPrice,double discountRate,string note, int initialStock, string quantityUnit, byte[] photo)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.CategoryID = categoryID;
            this.SuplierID = supplierID;
            this.Size = size;
            this.SizeUnit = sizeUnit;
            this.PurchasePrice = purchasePrice;
            this.RetailPrice = retailPrice;
            this.DiscountRate = discountRate;
            this.Note = note;
            this.Photo = photo;
            this.InitialStock = initialStock;
            this.QuantiyUnit = quantityUnit;

        }


        public Product( string productName, int categoryID, int supplierID, int size, string sizeUnit, double purchasePrice, double retailPrice, double discountRate, string note,int initialStock,string quantityUnit,byte[] photo)
        {
            this.ProductName = productName;
            this.CategoryID = categoryID;
            this.SuplierID = supplierID;
            this.Size = size;
            this.SizeUnit = sizeUnit;
            this.PurchasePrice = purchasePrice;
            this.RetailPrice = retailPrice;
            this.DiscountRate = discountRate;
            this.Note = note;
            this.Photo = photo;
            this.InitialStock = initialStock;
            this.QuantiyUnit = quantityUnit;

        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SuplierID { get; set; }
        public int CategoryID { get; set; }
        public int Size { get; set; }
        public string SizeUnit { get; set; }
        public double PurchasePrice { get; set; }
        public double RetailPrice { get; set; }
        public double DiscountRate { get; set; }
        public string Note { get; set; }
        public byte[] Photo { get; set; }
        public int InitialStock { get; private set; }
        public string QuantiyUnit { get; private set; }

        public void InsertProduct()
        {
            c.con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c.con;
            cmd.CommandText = "EXEC spInsertProducts @productName,@categoryID,@supplierID,@size,@sizeUnit,@purchasePrice,@retailPrice,@discountRate,@note,@initialStock,@quantityUnit,@photo";
            cmd.Parameters.AddWithValue("@productName", ProductName);
            cmd.Parameters.AddWithValue("@categoryID", CategoryID);
            cmd.Parameters.AddWithValue("@supplierID", SuplierID);
            cmd.Parameters.AddWithValue("@size", Size);
            cmd.Parameters.AddWithValue("@sizeUnit", SizeUnit);
            cmd.Parameters.AddWithValue("@purchasePrice", PurchasePrice);
            cmd.Parameters.AddWithValue("@retailPrice", RetailPrice);
            cmd.Parameters.AddWithValue("@discountRate", DiscountRate);
            cmd.Parameters.AddWithValue("@note", Note);
            cmd.Parameters.AddWithValue("@initialStock", InitialStock);
            cmd.Parameters.AddWithValue("@quantityUnit", QuantiyUnit);
            cmd.Parameters.AddWithValue("@photo", Photo);
            cmd.ExecuteNonQuery();
            c.con.Close();

            MessageBox.Show("Producet added Successfully!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
