namespace Universal.Service
{
    using Core;
	using Common;
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

        public async Task<Response<CompanyDetailResponse>> InsertAsync(CompanyDetailRegisterDto Model)
        {
            Data = Mapper.Map<CompanyDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<CompanyDetail>(Data);
            await UnitOfWork.CompanyDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyDetailResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetailResponse>> UpdateAsync(CompanyDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyDetail>(Collection[0]);
            Data.Description = Model.Description;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.CompanyDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetailResponse>> DeleteAsync(CompanyDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<CompanyDetail>(Collection[0]);

            await UnitOfWork.CompanyDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetailResponse>> SelectAsync(CompanyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.IsActive == true);
            return new Response<CompanyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CompanyDetailResponse>> SelectSingleAsync(CompanyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CompanyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}