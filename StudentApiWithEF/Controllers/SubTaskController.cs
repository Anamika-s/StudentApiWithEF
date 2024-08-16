using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApiWithEF.Context;
using StudentApiWithEF.Models;

namespace StudentApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        TaskDbContext context;
        public SubTaskController(TaskDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.SubTasks.ToList());
        }


        [HttpPost]
        public IActionResult AddSubTask(SubTask subtask)
        {
            context.SubTasks.Add(subtask);
            context.SaveChanges();
            return Created("added", subtask);
        }

    }
}
