/**Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as Qty *Price
Pass the other information like SalesNo, Productno, Price,Qty and Dateof sale through constructor
call the show data method to display the values.
Hint : Use This pointer
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Q3_Saledetail
    {
        class Saledetails
        {
            private int SalesNo;
            private int ProductNo;
            private double Price;
            private DateTime DateofSale;
            private int Qty;
            private double TotalAmount;

            public Saledetails(int salesNo, int productNo, double price, int qty, DateTime dateofSale)
            {
                SalesNo = salesNo;
                ProductNo = productNo;
                Price = price;
                Qty = qty;
                DateofSale = dateofSale;
                Sales();
            }

            public void Sales()
            {
                TotalAmount = Qty * Price;
            }

            public void ShowData()
            {
                Console.WriteLine("Sales No: " + SalesNo);
                Console.WriteLine("Product No: " + ProductNo);
                Console.WriteLine("Price: " + Price);
                Console.WriteLine("Quantity: " + Qty);
                Console.WriteLine("Date of Sale: " + DateofSale.ToString("yyyy-MM-dd"));
                Console.WriteLine("Total Amount: " + TotalAmount);
            }
        }
        class Program
        {
            static void Main()
            {

                Saledetails sale1 = new Saledetails(1, 101, 24.5, 7, DateTime.Now);
                sale1.ShowData();
                Console.ReadLine();
            }
        }
    }
}
