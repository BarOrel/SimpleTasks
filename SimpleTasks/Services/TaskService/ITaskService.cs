using SimpleTasks.Data.Models;

namespace SimpleTasks.Services.TaskService
{
    public interface ITaskService
    {
        Task AddTask(TaskModel task);
        Task DeleteTask(Guid taskId);
        Task EditTask(TaskModel task);
        Task<IEnumerable<TaskModel>> GetTasksByUser(string UserId);


    }
}
