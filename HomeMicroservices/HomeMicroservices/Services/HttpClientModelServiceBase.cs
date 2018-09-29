using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace HomeMicroservices.Services
{
    public abstract class HttpClientModelServiceBase<T> : IModelService<T>
    {
        private readonly HttpClient httpClient;

        private readonly string inventoryAPIBaseRoute;

        public HttpClientModelServiceBase(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.httpClient = httpClient;

            httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("access_token", out string token);
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            this.inventoryAPIBaseRoute = configuration["InventoryAPIURL"];
        }

        public abstract string GetBaseRoute();

        public async Task<bool> Create(T data)
        {
            string url = string.Format("{0}/{1}/new", this.inventoryAPIBaseRoute, this.GetBaseRoute());
            var result = await httpClient.PostAsJsonAsync(url, data);

            return result.StatusCode == HttpStatusCode.OK ? true : false;
        }

        public async Task<bool> Delete(Guid id)
        {
            string url = string.Format("{0}/{1}/{2}", this.inventoryAPIBaseRoute, this.GetBaseRoute(), id);
            var result = await httpClient.DeleteAsync(url);

            return result.StatusCode == HttpStatusCode.OK ? true : false;
        }

        public async Task<ICollection<T>> GetAll(BsonDocument filter = null)
        {
            string url = string.Format("{0}/{1}", this.inventoryAPIBaseRoute, this.GetBaseRoute());
            var result = await httpClient.GetAsync(url);

            if(result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ICollection<T>>(await result.Content.ReadAsStringAsync());
            }

            return new List<T>();
        }

        public async Task<T> GetByID(Guid id)
        {
            string url = string.Format("{0}/{1}/{2}", this.inventoryAPIBaseRoute, this.GetBaseRoute(), id);
            var result = await httpClient.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
            }

            return default;
        }

        public async Task<bool> Update(Guid id, T data)
        {
            string url = string.Format("{0}/{1}/{2}", this.inventoryAPIBaseRoute, this.GetBaseRoute(), id);
            var result = await httpClient.PostAsJsonAsync(url, data);

            return result.StatusCode == HttpStatusCode.OK ? true : false;
        }
    }
}
