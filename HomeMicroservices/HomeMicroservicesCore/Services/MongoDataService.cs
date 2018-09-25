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

        private MongoClient _mongoClient;
        public MongoClient MongoClient
        {
            get
            {
                if(this._mongoClient != null)
                {
                    return this._mongoClient;
                }

                this.MongoClient = new MongoClient(this.configuration["Data:ConnectionStrings:MongoDB"]);
                return this._mongoClient;
            }
            set
            {
                this._mongoClient = value;
            }
        }

        private IMongoDatabase _mongoDatabase;
        public IMongoDatabase MongoDatabase
        {
            get
            {
                if(this._mongoDatabase != null)
                {
                    return this._mongoDatabase;
                }

                this.MongoDatabase = this.MongoClient.GetDatabase(this.configuration["Data:Database"]);
                return this._mongoDatabase;
            }
            set
            {
                this._mongoDatabase = value;
            }
        }


        public MongoDataService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
