using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.API.Ports
{
    interface IAmAEventPublisher
    {
        Task<bool> SendTodo(TodoItem todo);
    }
}
