namespace Universal.Service
{
    using Core;
	using Common;
	using AutoMapper;
    using FluentValidation;

    public class ManagementDetailManager : BusinessObject<ManagementDetail>, IManagementDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<ManagementDetail> Validator;

        public ManagementDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ManagementDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<ManagementDetailResponse>> InsertAsync(ManagementDetailRegisterDto Model)
        {
            Data = Mapper.Map<ManagementDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<ManagementDetail>(Data);
            await UnitOfWork.ManagementDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementDetailResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetailResponse>> UpdateAsync(ManagementDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementDetail>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.ManagementDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetailResponse>> DeleteAsync(ManagementDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementDetail>(Collection[0]);

            await UnitOfWork.ManagementDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetailResponse>> SelectAsync(ManagementDetailSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.IsActive == true);
            return new Response<ManagementDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetailResponse>> SelectSingleAsync(ManagementDetailSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<ManagementDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}