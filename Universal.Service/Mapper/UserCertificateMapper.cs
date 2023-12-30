namespace Universal.Service
{
    public class UserCertificateMapper : AutoMapper.Profile
    {
        public UserCertificateMapper()
        {
            CreateMap<Core.UserCertificateRegisterDto, Core.UserCertificate>().ReverseMap();
            CreateMap<Core.UserCertificateUpdateDto, Core.UserCertificate>().ReverseMap();
        }
    }
}