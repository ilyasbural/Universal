namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class CompanyAboutManager : BusinessObject<CompanyAbout>, ICompanyAboutService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<CompanyAbout> Validator;

        public CompanyAboutManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CompanyAbout> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<CompanyAbout>> InsertAsync(CompanyAboutRegisterDto Model)
        {
            Data = Mapper.Map<CompanyAbout>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<CompanyAbout>(Data);
            await UnitOfWork.CompanyAbout.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyAbout>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        } 

        public Task<Response<CompanyAbout>> UpdateAsync(CompanyAboutUpdateDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CompanyAbout>> DeleteAsync(CompanyAboutDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<CompanyAbout>> SelectAsync(CompanyAboutSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.IsActive == true);
            return new Response<CompanyAbout>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<CompanyAbout>> SelectSingleAsync(CompanyAboutSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}