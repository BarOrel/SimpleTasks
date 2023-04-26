using Microsoft.AspNetCore.Identity;
using SimpleTasks.Data.Models.DTO;
using SimpleTasks.Data.Models;
using SimpleTasks.Data.Repository;
using System.Collections;

namespace SimpleTasks.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IGenericRepository<TaskModel> taskRepository;

        public TaskService(IGenericRepository<TaskModel> taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task AddTask(TaskModel task)
        {
            task.Id = Guid.NewGuid();
            try
            {
                await taskRepository.Insert(task);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteTask(Guid taskId)
        {
            try
            {
                var task = await taskRepository.GetById(taskId);
                await taskRepository.Delete(task);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task EditTask(TaskModel task)
        {
            try
            {
                await taskRepository.Update(task);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<IEnumerable<TaskModel>> GetTasksByUser(string UserId)
        {
            try
            {
                var Tasks = await taskRepository.GetAll();
                Tasks = Tasks.Where(task => task.User_Id == UserId);
                return Tasks;

            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

    }
}
