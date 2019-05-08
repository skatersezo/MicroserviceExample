using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.EventConsumer
{
    public class Config
    {
        public string BaseDataStoreUri { get; set; }
        public string StoreInsertTodo { get; set; }
        public string StoreSelectTodoById { get; set; }
    }
}
