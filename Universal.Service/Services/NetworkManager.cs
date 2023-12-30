namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class NetworkManager : BusinessObject<Network>, INetworkService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Network> Validator;

        public NetworkManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Network> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<Network>> InsertAsync(NetworkRegisterDto Model)
        {
            Data = Mapper.Map<Network>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Network>(Data);
            await UnitOfWork.Network.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Network>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Network>> SelectAsync()
        {
            Collection = await UnitOfWork.Network.SelectAsync(x => x.IsActive == true);
            return new Response<Network>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}