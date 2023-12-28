using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Models;
using WebService.Services;

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
            return Ok(_itemService.Get());
        }
    }
}
