using System.Collections.Generic;
using appointment_sys_api.Domain;

namespace appointment_sys_api.Boundary.Request;

public class ResidentRequest
{
  public int Id { get; set; }
  public string Name { get; set; }
}