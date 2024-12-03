using CoreERP.Dtos;
using CoreERP.Interfaces;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreERP.Repository
{
    public class UserRepository:IUserRepo

    {
        private readonly CoreErpdbContext _context;
        
        public UserRepository(CoreErpdbContext context) {
            
            _context = context;
        }
        public Login GetUserLogin(LoginDtos loginDtos)
        {
            // Hash the incoming password to match the stored hashed password
          //  string hashedPassword = HashPassword(loginDtos.Password);

            // Fetch user based on Username and hashed password
            return _context.Login.Where(x => x.Username == loginDtos.Username && x.Password == loginDtos.Password)
                           .FirstOrDefault();
        }

        public async Task<List<Vendor>> GetVendorsFromRepoMethod()
        {
            return await _context.Vendors.ToListAsync();
        }


    }
}
