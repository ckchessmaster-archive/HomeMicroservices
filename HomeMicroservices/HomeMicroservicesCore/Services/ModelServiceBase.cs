using HomeMicroservices.Factories;
using HomeMicroservices.Models;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Services
{
    public class ModelServiceBase<TModel> : IModelService<TModel>
    {
        IModelFactory<TModel> factory;
        private HttpContext httpContext;

        public ModelServiceBase(IModelFactory<TModel> factory, IHttpContextAccessor httpContextAccessor)
        {
            this.factory = factory as IModelFactory<TModel>;
            this.httpContext = httpContextAccessor.HttpContext;
        }

        public virtual async Task<bool> Create(TModel model)
        {
            model = this.InitializeModelForCreate(model);

            return await factory.Create(model);
        }

        protected virtual TModel InitializeModelForCreate(TModel model)
        {
            var modelBase = model as ModelBase;
            modelBase.ModelID = Guid.NewGuid();
            modelBase.CreateUser = httpContext.User.Claims.Where(c => c.Type.Equals("sub")).FirstOrDefault().Value;
            modelBase.CreateDate = DateTime.Now;
            modelBase.UpdateUser = modelBase.CreateUser;
            modelBase.UpdateDate = modelBase.CreateDate;

            return model;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            return await this.factory.Delete(id);
        }

        public virtual async Task<ICollection<TModel>> GetAll(BsonDocument filter = null)
        {
            return await this.factory.GetAll(filter);
        }

        public virtual async Task<TModel> GetByID(Guid id)
        {
            return await this.factory.GetByID(id);
        }

        public virtual async Task<bool> Update(Guid id, TModel model)
        {
            model = InitializeModelForUpdate(model);

            return await this.factory.Update(model);
        }

        protected virtual TModel InitializeModelForUpdate(TModel model)
        {
            var modelBase = model as ModelBase;
            modelBase.UpdateUser = httpContext.User.Claims.Where(c => c.Type.Equals("sub")).FirstOrDefault().Value;
            modelBase.UpdateDate = DateTime.Now;

            return model;
        }
    }
}
