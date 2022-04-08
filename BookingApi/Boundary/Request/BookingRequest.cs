using System.Collections.Generic;
using appointment_sys_api.Domain;

namespace appointment_sys_api.Boundary.Request;

public class BookingRequest
{
  public string Name {get; set;}
  public string Council {get; set;}
  public string Email {get; set;}
  public string JobTitle {get; set;}
  public string PhoneNumber {get; set;}
}