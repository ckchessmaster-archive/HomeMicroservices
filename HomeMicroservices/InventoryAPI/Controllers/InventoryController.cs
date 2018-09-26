using HomeMicroservices.Models;
using HomeMicroservices.Services;
using InventoryAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers
{
    [Route("inventory-api")]
    [ApiController]
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
        [Route("inventories")]
        public async Task<IActionResult> GetInventoryList()
        {
            return Ok(await inventoryService.GetAll());
        }

        [HttpPost]
        [Route("inventories/new")]
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
        [Route("inventories/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(await this.inventoryService.Delete(id))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpGet]
        [Route("inventories/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var inventory = this.inventoryService.GetByID(id);
            var items = this.itemService.GetAll(new BsonDocument { { "InventoryID", id } });

            return Ok(new InventoryDetailViewModel
            {
                Inventory = await inventory,
                Items = (await items).ToList()
            });
        }

        [HttpPost]
        [Route("inventories/{id}")]
        public async Task<IActionResult> Edit(Guid id, Inventory model)
        {
            if(await this.inventoryService.Update(model))
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
