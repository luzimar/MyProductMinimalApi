using FluentValidation.Results;

using System.Text.Json.Serialization;

namespace MyProductApi.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        
        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public abstract bool IsValid();
    }
}
