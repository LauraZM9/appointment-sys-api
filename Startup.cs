using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AppointmentDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();
        
        app.UseCors("AllowAllOrigins");

        app.UseEndpoints((endpoints => { endpoints.MapControllers();}));

    }
}