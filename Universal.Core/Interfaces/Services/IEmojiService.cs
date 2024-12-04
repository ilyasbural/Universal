namespace Universal.Core
{
    public interface IEmojiService
    {
        Task<Common.Response<Common.EmojiResponse>> InsertAsync(EmojiRegisterDto Model);
        Task<Common.Response<Common.EmojiResponse>> UpdateAsync(EmojiUpdateDto Model);
        Task<Common.Response<Common.EmojiResponse>> DeleteAsync(EmojiDeleteDto Model);
        Task<Common.Response<Common.EmojiResponse>> SelectAsync(EmojiSelectDto Model);
        Task<Common.Response<Common.EmojiResponse>> SelectSingleAsync(EmojiSelectDto Model);
    }
}