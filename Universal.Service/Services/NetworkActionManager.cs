namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class NetworkActionManager : BusinessObject<NetworkAction>, INetworkActionService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<NetworkAction> Validator;

        public NetworkActionManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<NetworkAction> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<NetworkActionResponse>> InsertAsync(NetworkActionRegisterDto Model)
        {
            Data = Mapper.Map<NetworkAction>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<NetworkAction>(Data);
            await UnitOfWork.NetworkAction.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkActionResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkActionResponse>> UpdateAsync(NetworkActionUpdateDto Model)
        {
            Collection = await UnitOfWork.NetworkAction.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkAction>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.NetworkAction.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkActionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkActionResponse>> DeleteAsync(NetworkActionDeleteDto Model)
        {
            Collection = await UnitOfWork.NetworkAction.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkAction>(Collection[0]);

            await UnitOfWork.NetworkAction.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkActionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkActionResponse>> SelectAsync(NetworkActionSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkAction.SelectAsync(x => x.IsActive == true);
            return new Response<NetworkActionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkActionResponse>> SelectSingleAsync(NetworkActionSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkAction.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<NetworkActionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}