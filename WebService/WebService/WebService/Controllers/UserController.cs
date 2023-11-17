using Microsoft.AspNetCore.Mvc;
using WebService.Models.Response;
using WebService.Requests;
using WebService.Services;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly iUserService _userService;
        public UserController(iUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] AuthRequest authRequest)
        {
            var Response = new Response();
            Response.Data = _userService.Auth(authRequest);
            if (Response.Data != null)
            {
                Response.Message = "Login Success";
                Response.Status = State.Success;
            }
            else
            {
                Response.Message = "Login Failed";
                return BadRequest(Response);
            }
            return Ok(Response);
        }
    }
}
