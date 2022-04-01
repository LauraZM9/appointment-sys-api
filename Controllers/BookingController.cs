using System;
using System.ComponentModel.DataAnnotations;
using appointment_sys_api.Boundary.Request;
using appointment_sys_api.Boundary.Response.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace appointment_sys_api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
  private readonly IFindBookingByIdUseCase _findByIdUseCase;
  public BookingController(IFindBookingByIdUseCase findByIdUseCase)
  {
    _findByIdUseCase = findByIdUseCase;
  }

  [HttpGet]
  [Route("{id}")]
  public IActionResult FindBooking([FromRoute] [Required] int id)
  {
    try
    {
      var result = _findByIdUseCase.Execute(id);
      return Ok(result);
    }
    catch (NotFoundException)
    {
      return NotFound();
    }
  }
}