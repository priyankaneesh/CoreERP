using CoreERP.Dtos;
using CoreERP.Models;

namespace CoreERP.Interfaces
{
    public interface IUserRepo
    {
        public Login GetUserLogin(LoginDtos  loginDtos);
    }
}
