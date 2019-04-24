using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Microservices.EventConsumer
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int Order { get; set; }
    }
}
