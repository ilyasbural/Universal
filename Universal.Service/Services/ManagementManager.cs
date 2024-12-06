namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class ManagementManager : BusinessObject<Management>, IManagementService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Management> Validator;

        public ManagementManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Management> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<ManagementResponse>> InsertAsync(ManagementRegisterDto Model)
        {
            Data = Mapper.Map<Management>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Management>(Data);
            await UnitOfWork.Management.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementResponse>> UpdateAsync(ManagementUpdateDto Model)
        {
            Collection = await UnitOfWork.Management.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Management>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Management.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementResponse>> DeleteAsync(ManagementDeleteDto Model)
        {
            Collection = await UnitOfWork.Management.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Management>(Collection[0]);

            await UnitOfWork.Management.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementResponse>> SelectAsync(ManagementSelectDto Model)
        {
            Collection = await UnitOfWork.Management.SelectAsync(x => x.IsActive == true);
            return new Response<ManagementResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementResponse>> SelectSingleAsync(ManagementSelectDto Model)
        {
            Collection = await UnitOfWork.Management.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<ManagementResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}