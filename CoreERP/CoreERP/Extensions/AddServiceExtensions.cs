using CoreERP.Helper;
using CoreERP.Interfaces;
using CoreERP.Models;
using CoreERP.Repository;
using CoreERP.Services;
using Microsoft.EntityFrameworkCore;

namespace CoreERP.Extensions
{
    public static class AddServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreErpdbContext>(options => options.UseSqlServer(configuration.GetConnectionString("defaultConnection")));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IUserRepo, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
