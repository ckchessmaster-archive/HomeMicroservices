using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeMicroservices.Factories
{
    public interface IModelFactory<TModel>
    {
        Task<ICollection<TModel>> GetAll();
        Task<TModel> GetByID(Guid id);
        Task<bool> Create(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(Guid id);
    }
}
