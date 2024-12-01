using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.Response;
using WebService.Requests;
using WebService.Services;

namespace WebService.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RequirementController : ControllerBase
    {
        private readonly iRequirementService _requirementService;
        public RequirementController(iRequirementService requirementService)
        {
            _requirementService = requirementService;

        }


        [HttpPost]
        public IActionResult Post([FromBody] RequirementRequest request)
        {
            Console.WriteLine("Request is: ", request.user);
            Response res = new Response();
            request.user = User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
            try
            {
                _requirementService.AddRequirement(request);
                res.Message = "Requirement added successfully";
                res.Status = State.Success;
                return Ok(res);
            }
            catch (System.Exception e)
            {
               res.Status = State.Error;
               res.Message = e.Message;
               return BadRequest(res);
            }
        }
        
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(){
            var response = new Response();
            try{
                response.Data = this._requirementService.GetAllRequirements();
                response.Message = "The requirements was send";
                response.Status = State.Success;
                return Ok(response);
            }catch(Exception ex){
                Console.WriteLine("Error: ", ex.Message);
                response.Message = "Error in the code";
                response.Status = State.Error;
                return BadRequest(response);
            }
            
        }

        [HttpGet]
        [Route("GetAllById")]

        public IActionResult GetAllById(){
            var response = new Response();
            short acc_id = short.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value);
            try{
                response.Data = this._requirementService.GetAllRequirementsById(acc_id);
                response.Message = "The requirements was send";
                response.Status = State.Success;
                return Ok(response);
            }catch(Exception ex){
                Console.WriteLine("Error: ", ex.Message);
                response.Message = "Error in the code";
                response.Status = State.Error;
                return BadRequest(response);
            }
        }
    }
}