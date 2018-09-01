using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Services
{
    public class MongoDataService
    {
        private readonly IConfiguration configuration;

        private MongoClient mongoClient;

        private IMongoDatabase mongoDatabase;

        public MongoDataService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MongoClient GetMongoClient()
        {
            return this.mongoClient ?? new MongoClient(this.configuration["Data:ConnectionStrings:MongoDB"]);
        }

        public IMongoDatabase GetMongoDatabase()
        {
            return this.mongoDatabase ?? this.GetMongoClient().GetDatabase(this.configuration["Data:Database"]);
        }
    }
}
