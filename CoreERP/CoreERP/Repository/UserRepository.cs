using CoreERP.Dtos;
using CoreERP.Interfaces;
using CoreERP.Models;

namespace CoreERP.Repository
{
    public class UserRepository:IUserRepo

    {
        private readonly CoreErpdbContext _context;
        
        public UserRepository(CoreErpdbContext context) {
            
            _context = context;
        }
        public Login GetUserLogin(Login  loginDtos)
        {

            return _context.Login.Where(x => x.Username == loginDtos.Username && x.Password == loginDtos.Password).FirstOrDefault();

        }

    }
}
