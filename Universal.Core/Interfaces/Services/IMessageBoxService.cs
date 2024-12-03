namespace Universal.Core
{
    public interface IMessageBoxService
    {
        Task<Response<MessageBox>> InsertAsync(MessageBoxRegisterDto Model);
        Task<Response<MessageBox>> UpdateAsync(MessageBoxUpdateDto Model);
        Task<Response<MessageBox>> DeleteAsync(MessageBoxDeleteDto Model);
        Task<Response<MessageBox>> SelectAsync(MessageBoxSelectDto Model);
        Task<Response<MessageBox>> SelectSingleAsync(MessageBoxSelectDto Model);
    }
}