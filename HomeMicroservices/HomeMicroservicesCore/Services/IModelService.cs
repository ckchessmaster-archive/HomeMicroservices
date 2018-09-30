using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeMicroservicesCore.Services
{
    public interface IModelService<TModel>
    {
        Task<ICollection<TModel>> GetAll(BsonDocument filter = null);
        Task<TModel> GetByID(Guid id);
        Task<bool> Create(TModel data);
        Task<bool> Update(Guid id, TModel data);
        Task<bool> Delete(Guid id);
    }
}
