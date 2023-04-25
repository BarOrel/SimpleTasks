using SimpleTasks.Data.Models;
using SimpleTasks.Data.Models.DTO;
using Task = System.Threading.Tasks.Task;

namespace SimpleTasks.Services.UserService
{
    public interface IUserService
    {

        public Task Register(RegisterDTO registerDTO);
        public  Task<Token> Login(LoginDTO loginDTO);
    }
}
