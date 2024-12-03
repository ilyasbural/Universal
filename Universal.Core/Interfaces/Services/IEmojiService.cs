namespace Universal.Core
{
    public interface IEmojiService
    {
        Task<Response<Emoji>> InsertAsync(EmojiRegisterDto Model);
        Task<Response<Emoji>> UpdateAsync(EmojiUpdateDto Model);
        Task<Response<Emoji>> DeleteAsync(EmojiDeleteDto Model);
        Task<Response<Emoji>> SelectAsync(EmojiSelectDto Model);
        Task<Response<Emoji>> SelectSingleAsync(EmojiSelectDto Model);
    }
}