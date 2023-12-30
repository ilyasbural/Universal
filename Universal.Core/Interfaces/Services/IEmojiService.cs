namespace Universal.Core
{
    public interface IEmojiService
    {
        Task<Response<Emoji>> InsertAsync(EmojiRegisterDto Model);
        Task<Response<Emoji>> SelectAsync();
    }
}