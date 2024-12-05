namespace Universal.Core
{
    public interface IMessageBoxService
    {
        Task<Common.Response<Common.MessageBoxResponse>> InsertAsync(MessageBoxRegisterDto Model);
        Task<Common.Response<Common.MessageBoxResponse>> UpdateAsync(MessageBoxUpdateDto Model);
        Task<Common.Response<Common.MessageBoxResponse>> DeleteAsync(MessageBoxDeleteDto Model);
        Task<Common.Response<Common.MessageBoxResponse>> SelectAsync(MessageBoxSelectDto Model);
        Task<Common.Response<Common.MessageBoxResponse>> SelectSingleAsync(MessageBoxSelectDto Model);
    }
}