// using IDentityServer4.EntityFramework.Options;
// using System;
using appointment_sys_api.Models;
using Microsoft.EntityFrameworkCore;

namespace appointment_sys_api.Data;

public class AppointmentDbContext : DbContext
{
  public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) {}
  public DbSet<User> Users {get; set;}
}