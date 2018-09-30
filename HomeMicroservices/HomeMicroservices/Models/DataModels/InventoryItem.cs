using HomeMicroservicesCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HomeMicroservices.Models
{
    public class InventoryItem : ModelBase
    {
        /// <summary>
        /// The id of the inventory that this item is a part of
        /// </summary>
        [BsonElement("InventoryID")]
        public Guid InventoryID { get; set; }

        /// <summary>
        /// Data based on fields from Inventory class
        /// </summary>
        [BsonElement("Data")]
        public BsonDocument Data { get; set; }
    }
}
