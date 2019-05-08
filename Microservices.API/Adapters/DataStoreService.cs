using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microservices.API.Ports;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microservices.API.Adapters
{
    public class DatastoreService : IAmATodoRetriever
    {
        private readonly HttpClient _httpClient;
        private readonly Config _config; // how this class works?

        public DatastoreService(HttpClient httpClient, IOptions<Config> config)
        {
            _httpClient = httpClient;
            _config = config.Value;

            _httpClient.BaseAddress = new Uri(_config.BaseDatastoreUri);
        }

        public async Task<Todo> SelectTodoById(string id)
        {
            var uri = string.Format(_config.StoreSelectTodoById, id);
            var response = await _httpClient.GetStringAsync(uri);
            var todo = JsonConvert.DeserializeObject<Todo>(response);

            return todo;
        }

        public Task<List<Todo>> SelectAllTodos()
        {
            throw new NotImplementedException();
        }
    }
}
