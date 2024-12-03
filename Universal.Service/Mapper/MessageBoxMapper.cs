namespace Universal.Service
{
    public class MessageBoxMapper : AutoMapper.Profile
    {
        public MessageBoxMapper()
        {
            CreateMap<Core.MessageBoxRegisterDto, Core.MessageBox>().ReverseMap();
            CreateMap<Core.MessageBoxUpdateDto, Core.MessageBox>().ReverseMap();
        }
    }
}