using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Models
{
    public class Inventory : ModelBase
    {
        [BsonElement("Fields")]
        public BsonDocument Fields { get; set; }

        [BsonElement("Sort")]
        public BsonDocument Sort { get; set; }

        [BsonElement("SharedGroups")]
        public BsonDocument SharedGroups { get; set; }

        [BsonElement("Items")]
        public ICollection<InventoryItem> Items { get; set; }
    }
}
