using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApiWithEF.Context;

namespace StudentApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        TaskDbContext context;
        public TaskController(TaskDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Tasks.ToList());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            foreach (var task in context.Tasks) {
                if (task.TaskId == id)
                {
                    return Ok(task);

                }
            }
                     return NotFound();

        }

        [HttpPost]
        public IActionResult Add(Models.Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
            return Created("added",task);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Models.Task task)
        {
            foreach (var obj in context.Tasks)
            {
                if (obj.TaskId == id)
                {
                    obj.CreatedDate = DateTime.Now;
                    obj.AssignedBy = "a";

                    break;
                }
            }
            context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            foreach (var obj in context.Tasks)
            {
                if (obj.TaskId == id)
                {
                    context.Tasks.Remove(obj);
                    break;


                }
            }
            context.SaveChanges();
            return Ok();
        }











    }
}
