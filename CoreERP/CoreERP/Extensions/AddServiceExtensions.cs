using CoreERP.Helper;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreERP.Extensions
{
    public static class AddServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext < CoreErpdbContext>(options => options.UseSqlServer(configuration.GetConnectionString("defaultConnection")));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
}
