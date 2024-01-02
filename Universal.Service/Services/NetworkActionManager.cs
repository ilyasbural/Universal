namespace Universal.Service
{
    using Core;
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

        public async Task<Response<NetworkAction>> InsertAsync(NetworkActionRegisterDto Model)
        {
            Data = Mapper.Map<NetworkAction>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<NetworkAction>(Data);
            await UnitOfWork.NetworkAction.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkAction>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public Task<Response<NetworkAction>> UpdateAsync(NetworkActionUpdateDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NetworkAction>> DeleteAsync(NetworkActionDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NetworkAction>> SelectAsync(NetworkActionSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkAction.SelectAsync(x => x.IsActive == true);
            return new Response<NetworkAction>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<NetworkAction>> SelectSingleAsync(NetworkActionSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}