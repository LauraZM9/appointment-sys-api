using System;

namespace appointment_sys_api.Boundary.Response;

public class BookingResponse
{
    public Guid Id { get; set; }
    // public string ReferenceId{ get; set; }
    public string Name { get; set; }
    public string Council { get; set; }
    public string Email { get; set; }
    public string JobTitle { get; set; }
    public string PhoneNumber { get; set; }
}