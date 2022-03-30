using Microsoft.AspNetCore.Mvc;

namespace appointment_sys_api.Controllers;

public class HealthCheckController : ControllerBase
{
  [HttpGet]
  [Route("healthcheck")]
  [ProducesResponseType(typeof(Dictionary<string, bool>), 200)]
  public IActionResult HealthCheck()
  {
      var result = new Dictionary<string, bool> { { "success", true } };

      return Ok(result);
  }
}