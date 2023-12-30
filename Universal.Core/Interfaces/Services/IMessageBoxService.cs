namespace Universal.Core
{
    public interface IMessageBoxService
    {
        Task<Response<MessageBox>> InsertAsync(MessageBoxRegisterDto Model);
        Task<Response<MessageBox>> SelectAsync();
    }
}