namespace Universal.Service
{
    public class EmojiMapper : AutoMapper.Profile
    {
        public EmojiMapper()
        {
            CreateMap<Core.EmojiRegisterDto, Core.Emoji>().ReverseMap();
            CreateMap<Core.EmojiUpdateDto, Core.Emoji>().ReverseMap();
        }
    }
}