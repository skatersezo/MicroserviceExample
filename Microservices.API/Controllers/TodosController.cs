using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.API.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly DatastoreService _datastoreService;
        private readonly EventConsumerService _eventConsumerService;

        public TodosController(ILogger logger, DatastoreService datastoreService, EventConsumerService eventConsumerService)
        {
            _logger = logger;
            _datastoreService = datastoreService;
            _eventConsumerService = eventConsumerService;
        }
        

        // GET api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> Get()
        {

            return null;
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(string id)
        {
            var todo = await _datastoreService.SelectTodoById(id);
            return Ok(todo);
        }

        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<Todo>> Post([FromBody] Todo todo)
        {
            todo.Id = $"{Guid.NewGuid()}";

            await _eventConsumerService.SendTodo(todo);

            return CreatedAtAction(nameof(Get), new {id = todo.Id}, todo);
        }

    }
}
