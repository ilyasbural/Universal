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

        public Task<Response<ManagementDetail>> DeleteAsync(ManagementDetailDeleteDto Model)
        {
            throw new NotImplementedException();
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

        public async Task<Response<ManagementDetail>> SelectAsync()
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

        public Task<Response<ManagementDetail>> SelectAsync(ManagementDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ManagementDetail>> SelectSingleAsync(ManagementDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ManagementDetail>> UpdateAsync(ManagementDetailUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}