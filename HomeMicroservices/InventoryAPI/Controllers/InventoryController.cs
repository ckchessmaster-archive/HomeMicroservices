using HomeMicroservices.Models;
using HomeMicroservices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers
{
    [Authorize]
    [Route("inventory-api")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IModelService<Inventory> inventoryService;

        public InventoryController(IModelService<Inventory> inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("inventories")]
        public async Task<ActionResult<ICollection<Inventory>>> GetInventoryList()
        {
            var result = await inventoryService.GetAll();
            return result.ToList();
        }
    }
}
