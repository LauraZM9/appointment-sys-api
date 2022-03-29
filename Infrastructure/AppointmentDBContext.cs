using IDentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

public class AppointmentDbContext : DbContext
{
  public AppointmentDbContext(DbContextOptions options) : base(options) {}
  public DbSet<UserEntity> User {get; set;}
}