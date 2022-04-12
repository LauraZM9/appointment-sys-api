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
      services.AddScoped<ICreateBookingUseCase, CreateBookingUseCase>();
      


      services.AddCors(options =>
        {
            // change cors policy to only allow our frontend & localhost.
            options.AddPolicy("AllowAllOrigins",
            builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
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

        app.UseCors("AllowAllOrigins");

        app.UseEndpoints((endpoints => { endpoints.MapControllers();}));
    }
}