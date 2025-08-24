namespace Backend.Api.Configurations
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApplicationMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();                       

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend.Api Api");
            });

            app.UseRouting()           
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            

            app.UseExceptionHandler(options => { });

            return app;
        }
    }
}
