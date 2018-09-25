using System.Collections.Generic;

namespace HomeMicroservices.Models.ViewModels
{
    public class InventoryDetailView
    {
        public Inventory Inventory { get; set; }

        public List<InventoryItem> Items { get; set; }

        public InventoryDetailView()
        {
            this.Items = new List<InventoryItem>();
        }
    }
}
