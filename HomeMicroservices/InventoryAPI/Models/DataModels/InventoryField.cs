using InventoryAPI.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Models
{
    public class InventoryField
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Type")]
        public InventoryFieldType Type { get; set; }

        [BsonElement("DefaultSort")]
        public bool DefaultSort { get; set; }
    }
}
