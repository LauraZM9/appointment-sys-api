using System.Collections.Generic;
// using System.Linq;
using appointment_sys_api.Data;
using appointment_sys_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace appointment_sys_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly AppointmentDbContext _context;
    public TestController(AppointmentDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }
}