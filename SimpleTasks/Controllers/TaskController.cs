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

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetTasks(string UserId)
        {
            try
            {
                var TasksByUser = await taskService.GetTasksByUser(UserId);
                return Ok(TasksByUser);
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

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            try
            {
                await taskService.DeleteTask(taskId);
                return Ok($"Task : {taskId} \nHas Been Deleted");
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPatch]
        public async Task<IActionResult> EditTask(TaskModel task)
        {
            try
            {
                await taskService.EditTask(task);
                return Ok(task);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

    }
}
