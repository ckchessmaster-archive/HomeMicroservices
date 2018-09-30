using HomeMicroservicesCore.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeMicroservicesCore.Factories
{
    public class ModelFactoryBase<TModel> : IModelFactory<TModel>
    {
        private readonly IMongoCollection<TModel> collection;

        public ModelFactoryBase(MongoDataService dataService)
        {
            this.collection = dataService.MongoDatabase.GetCollection<TModel>(typeof(TModel).Name);
        }

        public virtual async Task<bool> Create(TModel model)
        {
            await this.collection.InsertOneAsync(model);

            return true;
        }

        public virtual async Task<bool> Delete(BsonDocument filter)
        {
            var result = await this.collection.DeleteOneAsync(filter);

            return result.IsAcknowledged;
        }

        public virtual async Task<ICollection<TModel>> GetAll(BsonDocument filter = null)
        {
            var cursor = await collection.FindAsync(filter ?? new BsonDocument());
            return await cursor.ToListAsync();
        }

        public virtual async Task<TModel> GetByID(BsonDocument filter)
        {
            var cursor = await collection.FindAsync(filter);

            return await cursor.FirstAsync();
        }

        public virtual async Task<bool> Update(BsonDocument filter, TModel model)
        {
            var result = await this.collection.FindOneAndReplaceAsync(filter, model);

            return result != null ? true : false;
        }
    }
}
