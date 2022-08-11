using MyProductApi.Models;
using MyProductApi.Services;

namespace MyProductApi.Routes
{
    public static class ProductRoutes
    {
        public static void GetProductRoutes(this WebApplication app)
        {
            app.MapGet("/products", (IProductService productService) =>
            {
                return productService.GetProducts();
            }).WithName("GetProducts");

            app.MapGet("/product/{id:guid}", (IProductService productService, Guid id) =>
            {
                return productService.GetProductById(id);
            }).WithName("GetProductById");

            app.MapGet("/product/{name}", (IProductService productService, string name) =>
            {
                return productService.GetProductByName(name);
            }).WithName("GetProductByName");

            app.MapGet("/product/{id:guid}/tags", (IProductService productService, Guid id) =>
            {
                return productService.GetProductTags(id);
            }).WithName("GetProductTags");

            app.MapPost("/products", (IProductService productService, Product product) =>
            {
                var response = productService.AddProduct(product);
                if (response.Success)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithName("AddProduct");

            app.MapPost("/product/{id:guid}/tags", (IProductService productService, Guid id, string tag) =>
            {
                var response = productService.AddProductTags(id, tag);
                if (response.Success)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithName("AddProductTags");
        }
    }
}
