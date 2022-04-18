using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type a new Department name: ");

            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);

            var departments = repo.GetAllDepartments();

            Console.WriteLine("Here is the new list of departments: ");

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }

            Console.WriteLine("----------");

            // ------------------------------------------------Exercise 2

            var repo2 = new DapperProductRepository(conn);

            Console.WriteLine("Enter a new Product: ");
            var newProduct = Console.ReadLine();

            Console.WriteLine("What is that product's price? ");
            var price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("What is that product's category ID? ");
            var categoryID = Convert.ToInt32(Console.ReadLine());

            repo2.CreateProduct(newProduct, price, categoryID);

            var products = repo2.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine(prod.Name);
            }

            Console.WriteLine("Product added!");
            Console.WriteLine("----------");

            // ------------------------------------------------Bonus

            var bonus = new DapperProductRepository(conn);

            Console.WriteLine("To update a product, first enter the productID: ");
            var newID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the new name of the product: ");
            var newName = Console.ReadLine();

            bonus.UpdateProduct(newID, newName);

            Console.WriteLine("Product updated!");
            Console.WriteLine("----------");

            // -----------------------------------------------Extra Bonus

            var extraBonus = new DapperProductRepository(conn);

            Console.WriteLine("To delete a product, enter the productID: ");
            var prodID = Convert.ToInt32(Console.ReadLine());

            extraBonus.DeleteProduct(prodID);

            Console.WriteLine("Product deleted!");
            Console.WriteLine("----------");
        }
    }
}
