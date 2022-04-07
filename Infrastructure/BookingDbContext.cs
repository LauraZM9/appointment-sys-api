using System;
using System.Linq;
using appointment_sys_api.Domain;
using Microsoft.EntityFrameworkCore;
using appointment_sys_api.Infrastructure.Interfaces;

namespace appointment_sys_api.Infrastructure;

public class BookingDbContext : DbContext
{
  public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) {}
  public DbSet<Booking> Bookings {get; set;}

  public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntity && (e.State == EntityState.Added));

        foreach (var entityEntry in entries)
        {
            var entity = ((IEntity) entityEntry.Entity);
            // if (entity.Id == default) entity.Id = Guid.NewGuid();
            // if (entity.Name == default) entity.Name = ;
        }

        return base.SaveChanges();
    }
}