using HomeMicroservices.Models;
using HomeMicroservices.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Factories
{
    public class InventoryTemplateFactory : IModelFactory<InventoryTemplate>
    {
        private const string COLLECTION_NAME = "InventoryTemplate";

        private readonly IMongoCollection<InventoryTemplate> collection;

        public InventoryTemplateFactory(MongoDataService dataService)
        {
            this.collection = dataService.GetMongoDatabase().GetCollection<InventoryTemplate>(COLLECTION_NAME);
        }

        public async Task<bool> Create(InventoryTemplate model)
        {
            await this.collection.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await this.collection.DeleteOneAsync(new BsonDocument
            {
                {"_id", id }
            });

            return result.IsAcknowledged;
        }

        public async Task<ICollection<InventoryTemplate>> GetAll()
        {
            var cursor = await collection.FindAsync(new BsonDocument());
            return await cursor.ToListAsync();
        }

        public async Task<InventoryTemplate> GetByID(string id)
        {
            var cursor = await collection.FindAsync(new BsonDocument
            {
                {"_id", id }
            });

            return await cursor.FirstAsync();
        }

        public async Task<bool> Update(InventoryTemplate model)
        {
            var result = await this.collection.UpdateOneAsync(new BsonDocument
            {
                {"_id", model.InventoryTemplateID }
            }, new BsonDocument { });

            return result.IsAcknowledged;
        }
    }
}
