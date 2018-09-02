using System;
using System.Threading.Tasks;
using HomeMicroservices.Models;
using HomeMicroservices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeMicroservices.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly IModelService<Inventory> inventoryService;

        public InventoryController(IModelService<Inventory> inventoryService)
        {
            this.inventoryService = inventoryService;
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
            return View(await this.inventoryService.GetByID(id));
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
    }
}