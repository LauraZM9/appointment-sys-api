using System;
using System.ComponentModel.DataAnnotations;
using appointment_sys_api.Boundary.Request;
using appointment_sys_api.Boundary.Response.Exceptions;
using appointment_sys_api.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace appointment_sys_api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BookingController : ControllerBase
{
  private ICreateBookingUseCase _createBookingUseCase;
  private readonly IFindBookingByIdUseCase _findByIdUseCase;
  public BookingController(ICreateBookingUseCase createBookingUseCase, IFindBookingByIdUseCase findByIdUseCase)
  {
    _createBookingUseCase = createBookingUseCase;
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

  [HttpPost]
  public IActionResult CreateBooking(BookingRequest request)
  {
    try 
    {
      var result = _createBookingUseCase.Execute(request);
      return Created(new Uri($"/booking/{result}", UriKind.Relative), result);
    }
    catch (NotFoundException)
      {
        return NotFound();
      }
  }
}