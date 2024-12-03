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

        public async Task<Response<CompanyAbout>> UpdateAsync(CompanyAboutUpdateDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyAbout>(Collection[0]);
            Data.Description = Model.Description;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.CompanyAbout.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyAbout>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyAbout>> DeleteAsync(CompanyAboutDeleteDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyAbout>(Collection[0]);

            await UnitOfWork.CompanyAbout.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyAbout>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
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

        public async Task<Response<CompanyAbout>> SelectSingleAsync(CompanyAboutSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyAbout.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CompanyAbout>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}