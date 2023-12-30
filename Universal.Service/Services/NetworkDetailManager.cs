namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class NetworkDetailManager : BusinessObject<NetworkDetail>, INetworkDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<NetworkDetail> Validator;

        public NetworkDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<NetworkDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<NetworkDetail>> InsertAsync(NetworkDetailRegisterDto Model)
        {
            Data = Mapper.Map<NetworkDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<NetworkDetail>(Data);
            await UnitOfWork.NetworkDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkDetail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkDetail>> SelectAsync()
        {
            Collection = await UnitOfWork.NetworkDetail.SelectAsync(x => x.IsActive == true);
            return new Response<NetworkDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}