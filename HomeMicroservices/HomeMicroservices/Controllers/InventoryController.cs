using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeMicroservices.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeMicroservices.Controllers
{
    public class InventoryController : Controller
    {
        InventoryTemplateService inventoryTemplateService;

        public InventoryController(InventoryTemplateService inventoryTemplateService)
        {
            this.inventoryTemplateService = inventoryTemplateService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.inventoryTemplateService.GetAll());
        }
    }
}