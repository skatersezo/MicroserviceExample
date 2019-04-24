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
    public class HttpEventPublisher : IAmAEventPublisher
    {
        private readonly Config _config;
        private readonly HttpClient _httpClient;

        public HttpEventPublisher(Config config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }

        public async Task<bool> SendTodo(TodoItem todo)
        {
            var todoJson = JsonConvert.SerializeObject(todo);

            var response = await _httpClient.PostAsync(_config.TodoEventHandlerUri,
                new StringContent(todoJson, Encoding.Default, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }

    public static class HttpEventPublisherFactory
    {
        private static HttpEventPublisher _eventPublisher;

        public static HttpEventPublisher Instance(Config config)
        {
            if (_eventPublisher is null)
                return _eventPublisher = new HttpEventPublisher(config);

            return _eventPublisher;
        }
    }
}
