// using IDentityServer4.EntityFramework.Options;
using System;
using appointment_sys_api.Domain;
using Microsoft.EntityFrameworkCore;

public class AppointmentDbContext : DbContext
{
  public AppointmentDbContext(DbContextOptions options) : base(options) {}
  public DbSet<User> User {get; set;}
}