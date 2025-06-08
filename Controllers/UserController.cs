using Microsoft.AspNetCore.Mvc;

namespace SmartMarketplace.Controllers // ✅ Use correct namespace
{
  [ApiController]
  [Route("api/v1/users")]
  public class UserController : ControllerBase
  {
    [HttpGet]
    public ActionResult<string> GetUser()
    {
      return "User"; // automatically returns text/plain
    }
  }
}
