using Dapper;
using System.Collections.Generic;
using System.Data;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@productName, @price, @categoryID);",
                 new { productName = name, price = price, categoryID = categoryID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID",
                 new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID",
                 new { productID = productID });

            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID",
                 new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void UpdateProduct(int productID, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID",
                 new { newName = newName, productID = productID });
        }
    }
}
