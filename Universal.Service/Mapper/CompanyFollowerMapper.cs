namespace Universal.Service
{
    public class CompanyFollowerMapper : AutoMapper.Profile
    {
        public CompanyFollowerMapper()
        {
            CreateMap<Core.CompanyFollowerRegisterDto, Core.CompanyFollower>().ReverseMap();
            CreateMap<Core.CompanyFollowerUpdateDto, Core.CompanyFollower>().ReverseMap();
        }
    }
}