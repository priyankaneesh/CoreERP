using CoreERP.Dtos;
using CoreERP.Interfaces;
using CoreERP.Models;

namespace CoreERP.Services
{
    public class UserService:IUserService
    {
        private IUserRepo _userRepository;

public UserService(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }
        public Login GetUserLogin(Login  loginDtos)
        {

            return _userRepository.GetUserLogin(loginDtos);
        }
    }
}
