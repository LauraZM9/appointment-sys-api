using System;
using System.ComponentModel.DataAnnotations;
using appointment_sys_api.Boundary.Request;
using appointment_sys_api.Boundary.Response.Exceptions;
using appointment_sys_api.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace appointment_sys_api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
  private readonly IFindBookingByIdUseCase _findByIdUseCase;
  private ICreateBookingUseCase _createBookingUseCase;

  public BookingController(
    IFindBookingByIdUseCase findByIdUseCase,
    ICreateBookingUseCase createBookingUseCase)
  {
    _findByIdUseCase = findByIdUseCase;
    _createBookingUseCase = createBookingUseCase;
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
        return Created(new Uri($"/booking_requests/{result.Id}",UriKind.Relative),result);
    }
    catch (Exception) //not best practices
    {
        throw;
    }
  }
}