namespace Universal.Core
{
    public interface IPositionService
    {
        Task<Common.Response<Common.PositionResponse>> InsertAsync(PositionRegisterDto Model);
        Task<Common.Response<Common.PositionResponse>> UpdateAsync(PositionUpdateDto Model);
        Task<Common.Response<Common.PositionResponse>> DeleteAsync(PositionDeleteDto Model);
        Task<Common.Response<Common.PositionResponse>> SelectAsync(PositionSelectDto Model);
        Task<Common.Response<Common.PositionResponse>> SelectSingleAsync(PositionSelectDto Model);
    }
}