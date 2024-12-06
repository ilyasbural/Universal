namespace Universal.Service
{
    using Core;
	using Common;
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

        public async Task<Response<CompanyAboutResponse>> InsertAsync(CompanyAboutRegisterDto Model)
        {
            Data = Mapper.Map<CompanyAbout>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<CompanyAbout>(Data);
            await UnitOfWork.CompanyAbout.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyAboutResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        } 

        public async Task<Response<CompanyAboutResponse>> UpdateAsync(CompanyAboutUpdateDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyAbout>(Collection[0]);
            Data.Description = Model.Description;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.CompanyAbout.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyAboutResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyAboutResponse>> DeleteAsync(CompanyAboutDeleteDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyAbout>(Collection[0]);

            await UnitOfWork.CompanyAbout.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyAboutResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyAboutResponse>> SelectAsync(CompanyAboutSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.IsActive == true);
            return new Response<CompanyAboutResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyAboutResponse>> SelectSingleAsync(CompanyAboutSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CompanyAboutResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}