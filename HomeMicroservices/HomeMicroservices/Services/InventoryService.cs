using HomeMicroservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace HomeMicroservices.Services
{
    public class InventoryService : HttpClientModelServiceBase<Inventory>
    {
        public InventoryService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) 
            : base(httpClient, configuration, httpContextAccessor)
        {
        }

        public override string GetBaseRoute()
        {
            return "inventories";
        }
    }
}
