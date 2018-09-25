using System;
using System.Linq;
using System.Threading.Tasks;
using HomeMicroservices.Models;
using HomeMicroservices.Models.ViewModels;
using HomeMicroservices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace HomeMicroservices.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly IModelService<Inventory> inventoryService;
        private readonly IModelService<InventoryItem> itemService;

        public InventoryController(IModelService<Inventory> inventoryService, IModelService<InventoryItem> itemService)
        {
            this.inventoryService = inventoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.inventoryService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Inventory model)
        {
            await this.inventoryService.Create(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await this.inventoryService.Delete(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var inventory = this.inventoryService.GetByID(id);
            var items = this.itemService.GetAll(new BsonDocument { { "InventoryID", id } });

            return View(new InventoryDetailView
            {
                Inventory = await inventory,
                Items = (await items).ToList()
            });
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await this.inventoryService.GetByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Inventory model)
        {
            bool result = await this.inventoryService.Update(model);

            return RedirectToAction("Index");
        }

        public IActionResult GetAddFieldModal()
        {
            return PartialView();
        }
    }
}