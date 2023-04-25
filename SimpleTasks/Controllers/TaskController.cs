using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTasks.Data.Models;
using SimpleTasks.Data.Models.DTO;
using SimpleTasks.Services.TaskService;
using SimpleTasks.Services.UserService;

namespace SimpleTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks(RegisterDTO DTO)
        {
            try
            {
                //await userService.Register(DTO);
                return Ok("New User has been register");
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel task)
        {
            try
            {
                await taskService.AddTask(task);
                return Ok(task);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(RegisterDTO DTO)
        {
            try
            {
                //await userService.Register(DTO);
                return Ok("New User has been register");
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPatch]
        public async Task<IActionResult> EditTask(RegisterDTO DTO)
        {
            try
            {
                //await userService.Register(DTO);
                return Ok("New User has been register");
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

    }
}
