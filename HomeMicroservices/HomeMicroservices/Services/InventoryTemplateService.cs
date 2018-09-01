using HomeMicroservices.Factories;
using HomeMicroservices.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMicroservices.Services
{
    public class InventoryTemplateService : IModelService<InventoryTemplate>
    {
        InventoryTemplateFactory factory;

        public InventoryTemplateService(InventoryTemplateFactory inventoryTemplateFactory)
        {
            this.factory = inventoryTemplateFactory;
        }

        public async Task<bool> Create(InventoryTemplate model)
        {
            return await factory.Create(model);
        }

        public async Task<bool> Delete(string id)
        {
            return await this.factory.Delete(id);
        }

        public async Task<ICollection<InventoryTemplate>> GetAll()
        {
            return await this.factory.GetAll();
        }

        public async Task<InventoryTemplate> GetByID(string id)
        {
            return await this.factory.GetByID(id);
        }

        public async Task<bool> Update(InventoryTemplate model)
        {
            return await this.factory.Update(model);
        }
    }
}
