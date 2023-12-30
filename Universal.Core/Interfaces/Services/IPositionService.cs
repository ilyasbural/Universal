namespace Universal.Core
{
    public interface IPositionService
    {
        Task<Response<Position>> InsertAsync(PositionRegisterDto Model);
        Task<Response<Position>> SelectAsync();
    }
}