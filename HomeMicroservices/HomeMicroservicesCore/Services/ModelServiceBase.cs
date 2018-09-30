using HomeMicroservicesCore.Factories;
using HomeMicroservicesCore.Models;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservicesCore.Services
{
    public class ModelServiceBase<TModel> : IModelService<TModel>
    {
        IModelFactory<TModel> factory;
        private HttpContext httpContext;

        private string _userId;

        private string UserId
        {
            get
            {
                if(string.IsNullOrEmpty(_userId))
                {
                    this._userId = httpContext.User.Claims.Where(c => c.Type.Equals("sub")).FirstOrDefault().Value;
                }

                return this._userId;
            }
        }

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
            modelBase.CreateUser = this.UserId;
            modelBase.CreateDate = DateTime.Now;
            modelBase.UpdateUser = modelBase.CreateUser;
            modelBase.UpdateDate = modelBase.CreateDate;

            return model;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var filter = InitializeDefaultFilter();
            filter.Add(new BsonElement("_id", BsonValue.Create(id)));

            return await this.factory.Delete(filter);
        }

        public virtual async Task<ICollection<TModel>> GetAll(BsonDocument filter = null)
        {
            filter = InitializeDefaultFilter(filter);

            return await this.factory.GetAll(filter);
        }

        public virtual async Task<TModel> GetByID(Guid id)
        {
            var filter = InitializeDefaultFilter();
            filter.Add(new BsonElement("_id", BsonValue.Create(id)));

            return await this.factory.GetByID(filter);
        }

        public virtual async Task<bool> Update(Guid id, TModel model)
        {
            model = InitializeModelForUpdate(model);

            var filter = InitializeDefaultFilter();

            return await this.factory.Update(filter, model);
        }

        protected virtual TModel InitializeModelForUpdate(TModel model)
        {
            var modelBase = model as ModelBase;
            modelBase.UpdateUser = this.UserId;
            modelBase.UpdateDate = DateTime.Now;

            return model;
        }

        protected virtual BsonDocument InitializeDefaultFilter(BsonDocument filter = null)
        {
            if (filter != null)
            {
                filter.Add(new BsonElement("CreateUser", BsonValue.Create(this.UserId)));
            }
            else
            {
                filter = new BsonDocument
                {
                    { "CreateUser",  this.UserId }
                };
            }

            return filter;
        }
    }
}
