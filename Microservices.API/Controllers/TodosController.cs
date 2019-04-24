using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microservices.API.Adapters;
using Microservices.API.Ports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly Config _config;
        private readonly ILogger _logger;
        private readonly IAmAEventPublisher _eventPublisher;
        private readonly IAmATodoRetriever _todoRetriever;

        // GET api/todos
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {

            return Ok(Enumerable.Empty<TodoItem>());
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(string id)
        {
            return await _todoRetriever.ById(id); // what about the status code and the rest of the headers?
        }

        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post([FromBody] TodoItem todo)
        {
            todo.Id = $"{Guid.NewGuid()}";

            var successfulPublish = await _eventPublisher.SendTodo(todo);

            if (successfulPublish)
                return CreatedAtAction(nameof(Get), new {id = todo.Id}, todo);

            throw new WebException($"{todo.Id} was not sent successfully.");
        }

    }
}
