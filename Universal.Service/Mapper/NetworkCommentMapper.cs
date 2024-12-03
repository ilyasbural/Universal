namespace Universal.Service
{
    public class NetworkCommentMapper : AutoMapper.Profile
    {
        public NetworkCommentMapper()
        {
            CreateMap<Core.NetworkCommentRegisterDto, Core.NetworkComment>().ReverseMap();
            CreateMap<Core.NetworkCommentUpdateDto, Core.NetworkComment>().ReverseMap();
        }
    }
}