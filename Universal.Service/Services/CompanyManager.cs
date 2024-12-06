namespace Universal.Service
{
    using Core;
	using Common;
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

        public async Task<Response<CompanyResponse>> InsertAsync(CompanyRegisterDto Model)
        {
            Data = Mapper.Map<Company>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Company>(Data);
            await UnitOfWork.Company.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyResponse>> UpdateAsync(CompanyUpdateDto Model)
        {
            Collection = await UnitOfWork.Company.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Company>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Company.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyResponse>> DeleteAsync(CompanyDeleteDto Model)
        {
            Collection = await UnitOfWork.Company.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Company>(Collection[0]);

            await UnitOfWork.Company.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyResponse>> SelectAsync(CompanySelectDto Model)
        {
            Collection = await UnitOfWork.Company.SelectAsync(x => x.IsActive == true);
            return new Response<CompanyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyResponse>> SelectSingleAsync(CompanySelectDto Model)
        {
            Collection = await UnitOfWork.Company.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CompanyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}