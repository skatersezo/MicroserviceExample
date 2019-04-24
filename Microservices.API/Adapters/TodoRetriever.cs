using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microservices.API.Ports;
using Newtonsoft.Json;

namespace Microservices.API.Adapters
{
    public class TodoRetriever : IAmATodoRetriever
    {
        private readonly Config _config; // What's the purpose of Config object?
        private readonly HttpClient _httpClient;

        public TodoRetriever(Config config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }

        public async Task<TodoItem> ById(string id)
        {
            var todoJson = await _httpClient.GetStringAsync(string.Format(_config.StoreSelectTodoById, id));

            return JsonConvert.DeserializeObject<TodoItem>(todoJson);
        }

        public Task<List<TodoItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public static class TodoRetrieverFactory // Why a factory for the retriever?
        {
            private static TodoRetriever _todoRetriever;

            public static TodoRetriever Instance(Config config)
            {
                if (_todoRetriever is null)
                    return _todoRetriever = new TodoRetriever(config); // why not return the instance directly?

                return _todoRetriever;
            }
        }
    }
}
