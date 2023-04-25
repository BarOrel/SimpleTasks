using System.ComponentModel.DataAnnotations;

namespace SimpleTasks.Data.Models.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Full_Name is required")]
        public string Full_Name { get; set; }
    }
}
