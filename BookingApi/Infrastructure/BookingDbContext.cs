using System;
using appointment_sys_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace appointment_sys_api.Infrastructure;

public class BookingDbContext : DbContext
{
  public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) {}
  public DbSet<Booking> Bookings {get; set;}
}