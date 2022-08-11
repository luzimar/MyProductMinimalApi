using MyProductApi.Models;
using MyProductApi.ViewModels;

namespace MyProductApi.Services
{
    public interface IProductService
    {
        Product GetProductById(Guid productId);
        Product GetProductByName(string productName);
        IEnumerable<Product> GetProducts();
        IEnumerable<string> GetProductTags(Guid productId);

        Response AddProduct(Product product);
        Response AddProductTags(Guid productId, string tags);
    }
}