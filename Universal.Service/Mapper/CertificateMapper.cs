namespace Universal.Service
{
    public class CertificateMapper : AutoMapper.Profile
    {
        public CertificateMapper()
        {
            CreateMap<Core.CertificateRegisterDto, Core.Certificate>().ReverseMap();
            CreateMap<Core.CertificateUpdateDto, Core.Certificate>().ReverseMap();
        }
    }
}