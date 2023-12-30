namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class CompanyManager : BusinessObject<Company>, ICompanyService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Company> Validator;

        public CompanyManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Company> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<Company>> InsertAsync(CompanyRegisterDto Model)
        {
            Data = Mapper.Map<Company>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Company>(Data);
            await UnitOfWork.Company.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Company>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Company>> SelectAsync()
        {
            Collection = await UnitOfWork.Company.SelectAsync(x => x.IsActive == true);
            return new Response<Company>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}