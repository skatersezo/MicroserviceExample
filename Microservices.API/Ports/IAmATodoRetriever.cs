using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.API.Ports
{
    public interface IAmATodoRetriever
    {
        Task<TodoItem> ById(string id);
        Task<List<TodoItem>> GetAll();
    }
}
