using NetDevPack.Specification;

using System.Linq.Expressions;

namespace MyProductApi.Models.Specs
{
    public class ProductIsValidSpec : Specification<Product>
    {
        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => !string.IsNullOrEmpty(product.Name) && product.Price > 0;
        }
    }
}
