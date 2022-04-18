using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string name, double price, int categoryID);
        public void DeleteProduct(int productID);
        public void UpdateProduct(int productID, string newName);
    }
}
