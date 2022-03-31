using System;

namespace appointment_sys_api.Domain;

[Table("bookings")]
public class Booking : IEntity
{
  [Column("id")]
  public int Id {get; set;}

  [Column("first_name")]
  public string FirstName {get; set;}

  [Column("last_name")]
  public string LastName {get; set;}
}