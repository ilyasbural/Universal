namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class ManagementContactManager : BusinessObject<ManagementContact>, IManagementContactService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<ManagementContact> Validator;

        public ManagementContactManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ManagementContact> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<ManagementContact>> InsertAsync(ManagementContactRegisterDto Model)
        {
            Data = Mapper.Map<ManagementContact>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<ManagementContact>(Data);
            await UnitOfWork.ManagementContact.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementContact>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementContact>> UpdateAsync(ManagementContactUpdateDto Model)
        {
            Collection = await UnitOfWork.ManagementContact.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementContact>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.ManagementContact.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementContact>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementContact>> DeleteAsync(ManagementContactDeleteDto Model)
        {
            Collection = await UnitOfWork.ManagementContact.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<ManagementContact>(Collection[0]);

            await UnitOfWork.ManagementContact.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<ManagementContact>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementContact>> SelectAsync(ManagementContactSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementContact.SelectAsync(x => x.IsActive == true);
            return new Response<ManagementContact>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<ManagementContact>> SelectSingleAsync(ManagementContactSelectDto Model)
        {
            Collection = await UnitOfWork.ManagementContact.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<ManagementContact>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}