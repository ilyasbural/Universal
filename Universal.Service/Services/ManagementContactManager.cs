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

        public Task<Response<ManagementContact>> DeleteAsync(ManagementContactDeleteDto Model)
        {
            throw new NotImplementedException();
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

        public async Task<Response<ManagementContact>> SelectAsync()
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

        public Task<Response<ManagementContact>> SelectAsync(ManagementContactSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ManagementContact>> SelectSingleAsync(ManagementContactSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ManagementContact>> UpdateAsync(ManagementContactUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}