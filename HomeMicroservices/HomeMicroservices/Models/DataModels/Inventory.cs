using HomeMicroservicesCore.Models;
using System.Collections.Generic;

namespace HomeMicroservices.Models
{
    public class Inventory : ModelBase
    {
        /// <summary>
        /// The possible fields for this inventory.
        /// </summary>
        public List<InventoryField> Fields { get; set; }

        /// <summary>
        /// A list of group ids/user id that are allowed to use this inventory along with their permissions.
        /// </summary>
        public List<SharedGroup> SharedGroups { get; set; }

        public List<InventoryItem> Items { get; set; }

        public Inventory()
        {
            this.Fields = new List<InventoryField>();
            this.SharedGroups = new List<SharedGroup>();
            this.Items = new List<InventoryItem>();
        }
    }
}
