using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;    
namespace SEB
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=SKAB2-PC1;Initial Catalog=SEBDB;Integrated Security=True";

            // List categories
            Console.WriteLine("Product Categories:");
            List<Category> categories = Category.GetAll(connectionString);

            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
            }
            Console.WriteLine();

            //choose category
            Console.Write("Choose a category (by ID): ");
            int categoryId = int.Parse(Console.ReadLine());

            // List products
            Console.WriteLine($"Products in {categories.Single(c => c.Id == categoryId).Name}:");
            List<Product> products = Product.GetByCategoryId(categoryId, connectionString);
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Id}. {product.Name} ({product.Price:C2})");
            }
            Console.WriteLine();

            //choose products
            List<OrderDetail> details = new List<OrderDetail>();
            while (true)
            {
                Console.Write("Choose a product (by ID) or press Enter to finish: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;

                int productId = int.Parse(input);
                Product product = products.Single(p => p.Id == productId);

                Console.Write($"Quantity for {product.Name}: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderDetail detail = new OrderDetail
                {
                    Product = product,
                    Quantity = quantity
                };
                details.Add(detail);
            }

            // Create order
            Order order = new Order
            {
                Date = DateTime.Now,
                Details = details
            };
            order.TotalPrice = order.Details.Sum(d => d.Quantity * d.Product.Price);
            order.Insert(connectionString);

            //total price
            Console.WriteLine($"Order #{order.Id} ({order.Date}):");
            foreach (OrderDetail detail in order.Details)
            {
                Console.WriteLine($"{detail.Product.Name}: {detail.Quantity} x {detail.Product.Price:C2} = {(detail.Quantity * detail.Product.Price):C2}");
            }
            Console.WriteLine($"Total price: {order.TotalPrice:C2}");
            Console.ReadKey();



        }
    }
}