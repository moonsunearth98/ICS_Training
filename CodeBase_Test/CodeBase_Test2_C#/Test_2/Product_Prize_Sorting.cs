/**2. Create a Class called Products with Productid, Product Name, Price. 
 Accept 10 Products, sort them based on the price, and display the sorted Products**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2
{
    class Product_Prize_Sorting
    {
        public class Product
        {
            public int ProductId;
            public string ProductName;
            public double Price;
            public Product(int productId, string productName, double price)
            {
                ProductId = productId;
                ProductName = productName;
                Price = price;
            }
            public override string ToString()
            {
                return $"Product ID: {ProductId}, Product Name: {ProductName}, Price: {Price:C}";
            }
        }
        public class ProductCollector
        {
            public static void Main(string[] args)
            {
                List<Product> products = new List<Product>();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Enter details for Product {i + 1}:");
                    Console.Write("Product ID (Enter the Numbers): ");
                    int productId = int.Parse(Console.ReadLine());
                    Console.Write("Product Name(Enter the Strings): ");
                    string productName = Console.ReadLine();
                    Console.Write("Price(Enter the Numbers): ");
                    double price = double.Parse(Console.ReadLine());

                    products.Add(new Product(productId, productName, price));
                }
                products = products.OrderBy(p => p.Price).ToList();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("\nSorted Products by Price:");
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
                Console.ReadLine();
            }
        }

    }
}
