namespace Universal.Core
{
    public interface IPositionService
    {
        Task<Response<Position>> InsertAsync(PositionRegisterDto Model);
        Task<Response<Position>> UpdateAsync(PositionUpdateDto Model);
        Task<Response<Position>> DeleteAsync(PositionDeleteDto Model);
        Task<Response<Position>> SelectAsync(PositionSelectDto Model);
        Task<Response<Position>> SelectSingleAsync(PositionSelectDto Model);
    }
}