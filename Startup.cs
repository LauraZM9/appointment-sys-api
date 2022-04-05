using Microsoft.EntityFrameworkCore;
using appointment_sys_api.Infrastructure;
using appointment_sys_api.Gateways;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.UseCase;
using appointment_sys_api.UseCase.Interfaces;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      // database context
      services.AddDbContext<BookingDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

      // gateway
      services.AddScoped<IBookingsGateway, BookingsGateway>();
      // use case
      services.AddScoped<IFindBookingByIdUseCase, FindBookingByIdUseCase>();

      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints((endpoints => { endpoints.MapControllers();}));
    }
}