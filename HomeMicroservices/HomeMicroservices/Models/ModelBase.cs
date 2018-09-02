using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Models
{
    public class ModelBase
    {
        [BsonId]
        public Guid ModelID { get; set; }

        [BsonElement("Name")]
        [Required]
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
