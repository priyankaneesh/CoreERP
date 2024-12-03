using CoreERP.Dtos;
using CoreERP.Interfaces;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreERP.Services
{
    public class UserService:IUserService
    {
        private IUserRepo _userRepository;

public UserService(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }
        public Login GetUserLogin(LoginDtos  loginDtos)
        {

            return _userRepository.GetUserLogin(loginDtos);
        }
        public async Task<List<Vendor>> GetVendorsFromServiceMethod()
        {
            return await _userRepository.GetVendorsFromRepoMethod();
        }
    }
}
