using Microsoft.AspNetCore.Identity;

namespace SimpleTasks.Data.Models
{
    public class User : IdentityUser
    {
        public string Full_Name { get; set; }
    }
}
