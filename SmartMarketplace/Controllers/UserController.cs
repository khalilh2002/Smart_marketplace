using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartMarketplace.Models;
using SmartMarketplace.Repository.Interface;
using SmartMarketplace.Service.Interface;

namespace SmartMarketplace.Controllers // ✅ Use correct namespace
{
  [ApiController]
  [Route("api/v1/users")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
      var users =  await _userRepository.GetAllAsync(); ;
      return Ok(users);
    }
  }
}
