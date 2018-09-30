using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HomeMicroservicesCore.Models
{
    public class ModelBase
    {
        [BsonId]
        public Guid ModelID { get; set; }

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
    }
}
