namespace Universal.Service
{
    using Core;
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

        public async Task<Response<ManagementDetail>> InsertAsync(ManagementDetailRegisterDto Model)
        {
            Data = Mapper.Map<ManagementDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<ManagementDetail>(Data);
            await UnitOfWork.ManagementDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementDetail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetail>> UpdateAsync(ManagementDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementDetail>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.ManagementDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetail>> DeleteAsync(ManagementDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementDetail>(Collection[0]);

            await UnitOfWork.ManagementDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetail>> SelectAsync(ManagementDetailSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.IsActive == true);
            return new Response<ManagementDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementDetail>> SelectSingleAsync(ManagementDetailSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<ManagementDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}