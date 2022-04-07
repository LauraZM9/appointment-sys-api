using System;
using System.ComponentModel.DataAnnotations.Schema;
using appointment_sys_api.Infrastructure.Interfaces;

namespace appointment_sys_api.Domain;

[Table("bookings")]
public class Booking : IEntity
{
  [Column("id")]
  public int Id {get; set;}

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("name")]
  public string Name {get; set;}

  [Column("council")]
  public string Council {get; set;}

  [Column("email")]
  public string Email {get; set;}

  [Column("job_title")]
  public string JobTitle {get; set;}

  [Column("phone_number")]
  public string PhoneNumber {get; set;}
}