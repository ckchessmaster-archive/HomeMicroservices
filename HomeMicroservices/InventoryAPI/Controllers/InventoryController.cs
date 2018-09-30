using HomeMicroservices.Models;
using HomeMicroservicesCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers
{
    [Route("inventories")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IModelService<Inventory> inventoryService;
        private readonly IModelService<InventoryItem> itemService;

        public InventoryController(IModelService<Inventory> inventoryService, IModelService<InventoryItem> itemService)
        {
            this.inventoryService = inventoryService;
            this.itemService = itemService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetInventoryList()
        {
            return Ok(await inventoryService.GetAll());
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Create(Inventory model)
        {
            if(await this.inventoryService.Create(model))
            {
                return Ok();
            }

            // Need to better handle errors in the future
            return StatusCode(500);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(await this.inventoryService.Delete(id))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var inventory = await this.inventoryService.GetByID(id);
            inventory.Items = (await this.itemService.GetAll(new BsonDocument { { "InventoryID", id } })).ToList();

            return Ok(inventory);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Edit(Guid id, Inventory model)
        {
            if(await this.inventoryService.Update(id, model))
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
