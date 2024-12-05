using Microsoft.AspNetCore.Mvc;
using WebService.Models.Response;
using WebService.Services;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ItemAttributesController : ControllerBase
    {
        private readonly iItemAttributeService _itemAttributeService;

        public ItemAttributesController(iItemAttributeService itemAttributeService)
        {
            _itemAttributeService = itemAttributeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemAttributeResponse>> GetAll()
        {
            var attributes = _itemAttributeService.GetAll();
            return Ok(attributes);
        }
    }
}