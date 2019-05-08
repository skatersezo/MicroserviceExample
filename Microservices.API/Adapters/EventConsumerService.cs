using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microservices.API.Ports;
using Newtonsoft.Json;

namespace Microservices.API.Adapters
{
    public class EventConsumerService : IAmAEventPublisher
    {
        private readonly HttpClient _httpClient;
        private Config _config;

        public EventConsumerService(HttpClient httpClient, Config config)
        {
            _httpClient = httpClient;
            _config = config;

            _httpClient.BaseAddress = new Uri(_config.BaseEventConsumerUri);
        }

        public async Task<string> SendTodo(Todo todo)
        {
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.Default, "application/json");

            var response = await _httpClient.PostAsync(_config.TodoEventHandlerUri, content);

            response.EnsureSuccessStatusCode();

            return response.Headers.Location.ToString();
        }
    }
}
