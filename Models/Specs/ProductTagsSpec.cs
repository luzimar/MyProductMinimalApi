using NetDevPack.Specification;

using System.Linq.Expressions;

namespace MyProductApi.Models.Specs
{
    public class ProductTagsSpec : Specification<string>
    {
        public override Expression<Func<string, bool>> ToExpression()
        {
            return tags => tags != null && !string.IsNullOrEmpty(tags.Trim()) && 
                   !tags.Contains("\"") && tags.ToLower().Trim() != "null" && tags.ToLower().Trim().Replace(" ", "") != "null";
        }
    }
}
