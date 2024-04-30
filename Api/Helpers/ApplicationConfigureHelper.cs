namespace Api.Helpers
{
    public static class ApplicationConfigureHelper
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.MapControllers();
            return app;
        }
    }
}
