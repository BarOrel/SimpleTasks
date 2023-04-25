namespace SimpleTasks.Data.Models.DTO
{
    public class Token
    {
        public string Username { get; set; }
        public string Email{ get; set; }
        public string UserId { get; set; }
        public string Token_Key { get; set; }

        public Token(string username, string email, string userId)
        {
            Username = username;
            Email = email;
            UserId = userId;
        }
    }
}
