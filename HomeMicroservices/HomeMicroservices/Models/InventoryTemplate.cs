using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Models
{
    public class InventoryTemplate
    {
        [BsonId]
        public string InventoryTemplateID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("UserID")]
        public string UserID { get; set; }

        [BsonElement("CreateDate")]
        public DateTime CreateDate { get; set; }

        [BsonElement("UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [BsonElement("Fields")]
        public BsonDocument Fields { get; set; }

        [BsonElement("Sort")]
        public BsonDocument Sort { get; set; }

        [BsonElement("SharedGroups")]
        public BsonDocument SharedGroups { get; set; }
    }
}
