using FluentValidation.Results;

using MyProductApi.Models;
using MyProductApi.ViewModels;

namespace MyProductApi.Services
{
    public class BaseService
    {
        public List<string> Errors { get; set; } = new List<string>();

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public Response ReturnResponseError()
        {
            return new Response(false, Errors);
        }

        public Response ReturnResponseSuccess()
        {
            return new Response(true);
        }

        public Response ReturnResponse(Entity entity)
        {
            if (entity.ValidationResult.IsValid)
                return new Response(true);

            return new Response(false, entity.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
