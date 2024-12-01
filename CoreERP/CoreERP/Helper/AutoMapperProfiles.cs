using AutoMapper;
using CoreERP.Dtos;
using CoreERP.Migrations;

namespace CoreERP.Helper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LoginDtos, Login>().ReverseMap();
        }
    }
}
