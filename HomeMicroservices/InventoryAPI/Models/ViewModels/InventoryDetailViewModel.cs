using HomeMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Models.ViewModels
{
    public class InventoryDetailViewModel
    {
        public Inventory Inventory { get; set; }

        public List<InventoryItem> Items { get; set; }

        public InventoryDetailViewModel()
        {
            this.Items = new List<InventoryItem>();
        }
    }
}
