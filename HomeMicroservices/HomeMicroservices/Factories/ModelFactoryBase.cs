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
    public class ModelFactoryBase<TModel> : IModelFactory<TModel>
    {
        private readonly IMongoCollection<TModel> collection;

        public ModelFactoryBase(MongoDataService dataService)
        {
            this.collection = dataService.MongoDatabase.GetCollection<TModel>(typeof(TModel).Name);
        }

        public async Task<bool> Create(TModel model)
        {
            await this.collection.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await this.collection.DeleteOneAsync(new BsonDocument
            {
                {"_id", id }
            });

            return result.IsAcknowledged;
        }

        public async Task<ICollection<TModel>> GetAll()
        {
            var cursor = await collection.FindAsync(new BsonDocument());
            return await cursor.ToListAsync();
        }

        public async Task<TModel> GetByID(Guid id)
        {
            var cursor = await collection.FindAsync(new BsonDocument
            {
                {"_id", id }
            });

            return await cursor.FirstAsync();
        }

        public async Task<bool> Update(TModel model)
        {
            var result = await this.collection.UpdateOneAsync(new BsonDocument
            {
                {"_id", (model as ModelBase).ModelID }
            }, new BsonDocument { });

            return result.IsAcknowledged;
        }

    }
}
