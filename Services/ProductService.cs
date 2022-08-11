using MyProductApi.Models;
using MyProductApi.Models.Specs;
using MyProductApi.ViewModels;

namespace MyProductApi.Services
{
    public class ProductService : BaseService, IProductService
    {
        private List<Product> Products = new List<Product>
        {
            new Product("Smart TV", 800),
            new Product("Xbox Series S", 1500)
        };

        public Product GetProductByName(string productName)
        {
            return Products.FirstOrDefault(x => x.Name.ToLower().Trim().Contains(productName.ToLower().Trim()));
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public Product GetProductById(Guid productId)
        {
            return Products.FirstOrDefault(x => x.Id == productId);
        }

        public IEnumerable<string> GetProductTags(Guid productId)
        {
            var productTags = GetProductById(productId)?.Tags;
            return productTags ?? new List<string>();
        }

        public Response AddProduct(Product product)
        {
            if (product.IsValid())
                Products.Add(product);

            return ReturnResponse(product);
        }

        public Response AddProductTags(Guid productId, string tags)
        {
            if (!new ProductTagsSpec().IsSatisfiedBy(tags))
            {
                AddError("Tags is invalid");
                return ReturnResponseError();
            }

            var product = GetProductById(productId);
            if (product != null)
            {
                product.AddTags(tags);
                return ReturnResponseSuccess();
            }

            AddError("Product not found");
            return ReturnResponseError();
        }
    }
}
