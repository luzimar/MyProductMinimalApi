using FluentValidation.Results;
using MyProductApi.Models.Validators;

namespace MyProductApi.Models
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        private List<string> _tags;
        public IReadOnlyCollection<string> Tags => _tags;

        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public void AddTags(string tags)
        {
            _tags = _tags ?? new List<string>();

            if (tags.Contains(","))
                _tags.AddRange(tags.Split(",").ToList());
            else
                _tags.Add(tags);
        }

        public override bool IsValid()
        {
            //return new ProductIsValidSpec().IsSatisfiedBy(this);
            ValidationResult = new ProductValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
