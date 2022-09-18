using MyProductApi.Services;

namespace MyProductApi.Extensions
{
    public static class RegisterStartupServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IProductService, ProductService>();
            return builder;
        }
    }
}
