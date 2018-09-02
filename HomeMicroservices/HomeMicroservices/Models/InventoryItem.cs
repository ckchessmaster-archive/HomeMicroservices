using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Models
{
    public class InventoryItem
    {
        [BsonId]
        public string InventoryItemID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("CreateUser")]
        public string CreateUser { get; set; }

        [BsonElement("CreateDate")]
        public DateTime CreateDate { get; set; }

        [BsonElement("UpdateUser")]
        public string UpdateUser { get; set; }

        [BsonElement("UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [BsonElement("Data")]
        BsonDocument Data { get; set; }
    }
}
