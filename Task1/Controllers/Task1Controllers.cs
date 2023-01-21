using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task1.Services;
using Task1.Models;
using Task = Task1.Models.Task;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Task1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Task> Get() => Task1Service.GetAll();


        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id) 
        {
            var task = Task1Service.Get(id);
            if (task == null)
                return NotFound();
            return task;          
        }

        [HttpPost]
        public ActionResult Post(Task pizza)
        {
         
            Task1Service.Add(pizza);
            return CreatedAtAction(nameof(Post), new { Id = pizza.Id}, pizza);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,Task task)
        {
            if (id != task.Id)
                return BadRequest("id <> task.Id");
         
            var res = Task1Service.Update(task);
            if (!res)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            var task = Task1Service.Get(id);
            if (task == null)
                return NotFound();
            Task1Service.Delete(id);         
            return NoContent();
        }
    
    }
}
