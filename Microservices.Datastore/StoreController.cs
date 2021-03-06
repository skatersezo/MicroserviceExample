﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.Datastore.Model;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Datastore
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly Store _store;

        public StoreController(Store store)
        {
            _store = store;
        }

        [HttpPost]
        public ActionResult<Todo> InsertTodo([FromBody] Todo todo)
        {
            _store.Insert<Todo>(todo);
            return CreatedAtAction(nameof(SelectOneTodo), new {todo.Id}, todo);
        }

        [HttpGet("todo/{id}")]
        public ActionResult<Todo> SelectOneTodo(string id)
        {
            var todo = _store.Select<Todo>(id);

            return Ok(todo);
        }
    }
}
