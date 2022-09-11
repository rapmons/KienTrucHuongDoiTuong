using ProductManager.Models;

namespace ProductManager.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product? GetProductById(int Id)
        {
            // return _context.Products.Find(Id);
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }

        void IProductService.CreateProduct(Product product)
        {
            // throw new NotImplementedException();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        void IProductService.UpdateProduct(Product product)
        {
            var existedProduct = GetProductById(product.Id);
            if (existedProduct == null) return;
            existedProduct.Name = product.Name;
            existedProduct.Slug = product.Slug;
            existedProduct.Price = product.Price;
            existedProduct.Quantity = product.Quantity;
            existedProduct.CategoryId = product.CategoryId;
            _context.Products.Update(existedProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(int Id)
        {
            // throw new NotImplementedException();
            var product = GetProductById(Id);
            if (product == null) return;
            Console.WriteLine("oke");
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        List<Category> IProductService.GetCategories()
        {
            return _context.Category.ToList();
        }
    }
}