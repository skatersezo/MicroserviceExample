﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Datastore.Model
{
    public class Todo : IAmAStoreEntity
    {
        public string Id { get; set; }
        /*public string Title { get; set; }
        public bool Completed { get; set; }
        public int Order { get; set; }*/
    }
}
