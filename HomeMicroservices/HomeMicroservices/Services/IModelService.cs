using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Services
{
    public interface IModelService<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetByID(string id);
        Task<bool> Create(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(string id);
    }
}
