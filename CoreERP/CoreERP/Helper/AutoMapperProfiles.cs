using AutoMapper;
using CoreERP.Dtos;
 
using CoreERP.Models;

namespace CoreERP.Helper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LoginDtos, Login>().ReverseMap();
            CreateMap<CompanyDtos,Company>().ReverseMap();
        }
    }
}
