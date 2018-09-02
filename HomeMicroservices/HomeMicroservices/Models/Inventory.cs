using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
    }
}
