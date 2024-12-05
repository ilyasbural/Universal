namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class SurveyDetailManager : BusinessObject<SurveyDetail>, ISurveyDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<SurveyDetail> Validator;

        public SurveyDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<SurveyDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<SurveyDetailResponse>> InsertAsync(SurveyDetailRegisterDto Model)
        {
            Data = Mapper.Map<SurveyDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<SurveyDetail>(Data);
            await UnitOfWork.SurveyDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyDetailResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetailResponse>> UpdateAsync(SurveyDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyDetail>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.SurveyDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetailResponse>> DeleteAsync(SurveyDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyDetail>(Collection[0]);

            await UnitOfWork.SurveyDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetailResponse>> SelectAsync(SurveyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.IsActive == true);
            return new Response<SurveyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetailResponse>> SelectSingleAsync(SurveyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<SurveyDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}