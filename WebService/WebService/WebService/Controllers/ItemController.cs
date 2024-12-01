
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.Response;
using WebService.Services;
using WebsServices.Requests;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator, Manager, Supervisor, Warehouse Supervisor, Inventory Manager, Dispatcher")]
    public class ItemController : ControllerBase
    {
        private readonly iItemService _itemService;
        public ItemController(iItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Manager, Supervisor, Warehouse Supervisor, Inventory Manager, Dispatcher")]
        public IActionResult Get()
        {
            Response res = new Response();
            res.Status = State.Success;
            res.Message = "Items found";
            return Ok(_itemService.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Manager, Warehouse Supervisor, Inventory Manager")]
        public IActionResult Post([FromBody] ItemRequest item)
        {
            Response res = new Response();
            try{
                _itemService.Add(item);
                res.Status = State.Success;
                res.Message = "Item added";
            }
            catch(System.Exception ex){
                res.Status = State.Error;
                res.Message = ex.Message;
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
