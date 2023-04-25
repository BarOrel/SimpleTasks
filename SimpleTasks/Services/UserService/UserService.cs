using Microsoft.AspNetCore.Identity;
using SimpleTasks.Data.Models;
using SimpleTasks.Data.Models.DTO;
using ToDoListPractice.Data.Services.JWT;


namespace SimpleTasks.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManger;
        private readonly SignInManager<User> signInManager;
        private readonly IJWTTokenService tokenService;

        public UserService(UserManager<User> userManger,SignInManager<User> signInManager, IJWTTokenService tokenService)
        {
            this.userManger = userManger;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            User user = new()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Username,
                Full_Name = registerDTO.Full_Name,
            };
            var Registration = await userManger.CreateAsync(user, registerDTO.Password);
            if (!Registration.Succeeded)
                throw new Exception("Registration Failed");
        }

        public async Task<Token> Login(LoginDTO loginDTO)
        {
            var userFromDB = await userManger.FindByNameAsync(loginDTO.Username);
            if (userFromDB != null) 
            { 
                var CheckLogin = await signInManager.CheckPasswordSignInAsync(userFromDB, loginDTO.Password, false);
                
                if (!CheckLogin.Succeeded)
                   throw new Exception("Login Failed");

                Token token = new(
                    userFromDB.UserName,
                    userFromDB.Email,
                    userFromDB.Id);

                token.Token_Key = tokenService.GenerateToken(userFromDB);
                return token;
            }

            throw new Exception("Cannot Find User");
        }


    }
}
