using System.Threading.Tasks;
using Microservices.EventConsumer.Adapters;
using Microservices.EventConsumer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.EventConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateTodoCommandHandlerController : ControllerBase
    {
        private readonly DatastoreService _datastoreService;
        private readonly Config _config;

        public CreateTodoCommandHandlerController(DatastoreService datastoreService, IOptions<Config> config)
        {
            _datastoreService = datastoreService;
            _config = config.Value;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Post([FromBody] CreateTodoCommand command)
        {
            var todo = new Todo
            {
                Id = command.Id
            };

            var location = await _datastoreService.InsertTodo(todo);

            return Created(location, todo);
        }
    }
}
