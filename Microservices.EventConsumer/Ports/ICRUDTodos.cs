using System.Threading.Tasks;
using Microservices.EventConsumer.Model;

namespace Microservices.EventConsumer.Ports
{
    interface ICRUDTodos
    {
        Task<string> InsertTodo(Todo todo);
    }
}
