using PizzaApp.Models;
using PizzaApp.Models.DTOs;

namespace PizzaApp.Interfaces
{
    public interface IUserAuthService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserRegisterDTO registerDTO);
    }
}
