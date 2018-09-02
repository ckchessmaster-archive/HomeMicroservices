using HomeMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Services
{
    public interface IModelService<TModel>
    {
        Task<ICollection<TModel>> GetAll();
        Task<TModel> GetByID(Guid id);
        Task<bool> Create(TModel data);
        Task<bool> Update(TModel data);
        Task<bool> Delete(Guid id);
    }
}
