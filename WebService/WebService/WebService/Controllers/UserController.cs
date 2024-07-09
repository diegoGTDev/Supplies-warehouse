using Microsoft.AspNetCore.Mvc;
using WebService.Models.Common;
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
            Console.WriteLine("Request is: ", authRequest.Username);
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

        [HttpPost]
        [Route("verifySession")]
        public IActionResult VerifySession([FromBody] UserResponse request)
        {
            Console.WriteLine("Verifying Token in process with token: " + request.Token);
            var Response = new Response();
            if (_userService.VerifyToken(request.Token))
            {
                Response.Message = "Session Valid";
                Response.Status = State.Success;
                Response.Data = true;
                
            }
            else
            {
                Response.Message = "Session Invalid";
                Response.Status = State.Error;
                Response.Data = false;
                
            }
            return Ok(Response);

        }
    }
}
