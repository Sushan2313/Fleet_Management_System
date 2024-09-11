public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register CORS services with a named policy
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", builder =>
            {
                builder.WithOrigins("http://localhost:5132") // Replace with your allowed origin(s)
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        // CORS should be used here, before UseEndpoints
        app.UseCors("AllowSpecificOrigin");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
