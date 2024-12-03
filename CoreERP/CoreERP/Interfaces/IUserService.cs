using CoreERP.Dtos;
using CoreERP.Models;

namespace CoreERP.Interfaces
{
    public interface IUserService
    {
        public Login GetUserLogin(LoginDtos  loginmodel);
        public Task<List<Vendor>> GetVendorsFromServiceMethod();
    }
}
