namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<NetworkResponse>> InsertAsync(NetworkRegisterDto Model)
        {
            Data = Mapper.Map<Network>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Network>(Data);
            await UnitOfWork.Network.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkResponse>> UpdateAsync(NetworkUpdateDto Model)
        {
            Collection = await UnitOfWork.Network.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Network>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Network.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkResponse>> DeleteAsync(NetworkDeleteDto Model)
        {
            Collection = await UnitOfWork.Network.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Network>(Collection[0]);

            await UnitOfWork.Network.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkResponse>> SelectAsync(NetworkSelectDto Model)
        {
            Collection = await UnitOfWork.Network.SelectAsync(x => x.IsActive == true);
            return new Response<NetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkResponse>> SelectSingleAsync(NetworkSelectDto Model)
        {
            Collection = await UnitOfWork.Network.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<NetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}