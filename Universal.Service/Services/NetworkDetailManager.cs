namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<NetworkDetailResponse>> InsertAsync(NetworkDetailRegisterDto Model)
        {
            Data = Mapper.Map<NetworkDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<NetworkDetail>(Data);
            await UnitOfWork.NetworkDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkDetailResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkDetailResponse>> UpdateAsync(NetworkDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.NetworkDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkDetail>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.NetworkDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkDetailResponse>> DeleteAsync(NetworkDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.NetworkDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkDetail>(Collection[0]);

            await UnitOfWork.NetworkDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkDetailResponse>> SelectAsync(NetworkDetailSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkDetail.SelectAsync(x => x.IsActive == true);
            return new Response<NetworkDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkDetailResponse>> SelectSingleAsync(NetworkDetailSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<NetworkDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}