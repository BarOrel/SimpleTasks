
using Microsoft.IdentityModel.Tokens;
using SimpleTasks.Data.Models;

namespace ToDoListPractice.Data.Services.JWT
{
    public interface IJWTTokenService
    {
        string GenerateToken(User user);
      
    }
}
