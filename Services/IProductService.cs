using ProductManager.Models;

namespace ProductManager.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product? GetProductById(int Id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int Id);

        List<Category> GetCategories();

    }
}