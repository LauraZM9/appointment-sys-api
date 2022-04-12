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
        options.UseNpgsql(GetHerokuConnectionString()));

      // gateway
      services.AddScoped<IBookingsGateway, BookingsGateway>();
      // use case
      services.AddScoped<IFindBookingByIdUseCase, FindBookingByIdUseCase>();
      services.AddScoped<ICreateBookingUseCase, CreateBookingUseCase>();
      
      services.AddCors(options => { 
        options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
    }

    private string GetHerokuConnectionString() {
        // Get the connection string from the ENV variables
        string connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

        // parse the connection string
        var databaseUri = new Uri(connectionUrl);

        string db = databaseUri.LocalPath.TrimStart('/');
        string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

        return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
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