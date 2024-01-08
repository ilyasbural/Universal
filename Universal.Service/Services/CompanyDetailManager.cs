namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class CompanyDetailManager : BusinessObject<CompanyDetail>, ICompanyDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<CompanyDetail> Validator;

        public CompanyDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CompanyDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }    

        public async Task<Response<CompanyDetail>> InsertAsync(CompanyDetailRegisterDto Model)
        {
            Data = Mapper.Map<CompanyDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<CompanyDetail>(Data);
            await UnitOfWork.CompanyDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyDetail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetail>> UpdateAsync(CompanyDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyDetail>(Collection[0]);
            Data.Description = Model.Description;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.CompanyDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetail>> DeleteAsync(CompanyDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyDetail>(Collection[0]);

            await UnitOfWork.CompanyDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetail>> SelectAsync(CompanyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.IsActive == true);
            return new Response<CompanyDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetail>> SelectSingleAsync(CompanyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CompanyDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}