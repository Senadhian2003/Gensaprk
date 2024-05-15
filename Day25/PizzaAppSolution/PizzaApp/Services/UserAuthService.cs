using PizzaApp.Exceptions;
using PizzaApp.Interfaces;

using PizzaApp.Models;
using PizzaApp.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaApp.Services
{
    public class UserAuthService : IUserAuthService
    {

        private readonly IRepository<int, UserCredential> _userCredentialsRepo;
        private readonly IRepository<int, User> _userRepo;

        public UserAuthService(IRepository<int, User> userRepo, IRepository<int, UserCredential> userCredentialRepo)
        {
            _userCredentialsRepo = userCredentialRepo;
            _userRepo = userRepo;
        }
        public async Task<User> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userCredentialsRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var user = await _userRepo.Get(loginDTO.UserId);
                if (userDB.Status == "Active")
                    return user;
                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<User> Register(UserRegisterDTO employeeDTO)
        {
            User user = null;
            UserCredential userCredential = null;
            try
            {
                user = employeeDTO;
                userCredential = MapEmployeeUserDTOToUser(employeeDTO);
                user = await _userRepo.Add(user);
                userCredential.UserId = user.Id;
                userCredential = await _userCredentialsRepo.Add(userCredential);
                ((UserRegisterDTO)user).Password = string.Empty;
                return user;
            }
            catch (Exception) { }
            if (user != null)
                await RevertEmployeeInsert(user);
            if (userCredential != null && user == null)
                await RevertUserInsert(userCredential);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserInsert(UserCredential userCredential)
        {
            await _userCredentialsRepo.Delete(userCredential.UserId);
        }

        private async Task RevertEmployeeInsert(User user)
        {
            await _userRepo.Delete(user.Id);
        }

        private UserCredential MapEmployeeUserDTOToUser(UserRegisterDTO employeeDTO)
        {
            UserCredential userCredential = new UserCredential();
            userCredential.UserId = employeeDTO.Id;
            userCredential.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            userCredential.PasswordHashKey = hMACSHA.Key;
            userCredential.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return userCredential;
        }


    }
}
