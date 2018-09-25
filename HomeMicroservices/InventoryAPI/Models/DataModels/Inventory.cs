using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace HomeMicroservices.Models
{
    public class Inventory : ModelBase
    {
        /// <summary>
        /// The possible fields for this inventory.
        /// </summary>
        [BsonElement("Fields")]
        public List<InventoryField> Fields { get; set; }

        /// <summary>
        /// A list of group ids/user id that are allowed to use this inventory along with their permissions.
        /// </summary>
        [BsonElement("SharedGroups")]
        public List<SharedGroup> SharedGroups { get; set; }

        public Inventory()
        {
            this.Fields = new List<InventoryField>();
            this.SharedGroups = new List<SharedGroup>();
        }
    }
}
