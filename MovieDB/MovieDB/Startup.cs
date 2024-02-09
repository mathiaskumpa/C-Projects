using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

public class Startup {

     public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        // Make sure you call this before calling app.UseMvc()
        app.UseCors(
            options => options.WithOrigins("http://localhost:8080").AllowAnyMethod()
        );
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
    }
}