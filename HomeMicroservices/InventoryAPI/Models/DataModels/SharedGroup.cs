using HomeMicroservices.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Models
{
    public class SharedGroup
    {
        [BsonElement("GroupID")]
        public string GroupID { get; set; }

        [BsonElement("Permission")]
        public PermissionTypes Permission { get; set; }
    }
}
