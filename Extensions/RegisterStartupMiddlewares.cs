using MyProductApi.Routes;

namespace MyProductApi.Extensions
{
    public static class RegisterStartupMiddlewares
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.GetProductRoutes();
            return app;
        }
    }
}
