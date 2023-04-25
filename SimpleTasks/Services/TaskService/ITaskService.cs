using SimpleTasks.Data.Models;

namespace SimpleTasks.Services.TaskService
{
    public interface ITaskService
    {
        Task AddTask(TaskModel task);
    }
}
