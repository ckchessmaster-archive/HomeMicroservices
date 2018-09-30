﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeMicroservices.Factories
{
    public interface IModelFactory<TModel>
    {
        Task<ICollection<TModel>> GetAll(BsonDocument filter = null);
        Task<TModel> GetByID(BsonDocument filter);
        Task<bool> Create(TModel model);
        Task<bool> Update(BsonDocument filter, TModel model);
        Task<bool> Delete(BsonDocument filter);
    }
}
