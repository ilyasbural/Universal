namespace Universal.Service
{
    using Core;
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

        public async Task<Response<SurveyDetail>> InsertAsync(SurveyDetailRegisterDto Model)
        {
            Data = Mapper.Map<SurveyDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<SurveyDetail>(Data);
            await UnitOfWork.SurveyDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyDetail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetail>> UpdateAsync(SurveyDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyDetail>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.SurveyDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetail>> DeleteAsync(SurveyDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyDetail>(Collection[0]);

            await UnitOfWork.SurveyDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetail>> SelectAsync(SurveyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.IsActive == true);
            return new Response<SurveyDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyDetail>> SelectSingleAsync(SurveyDetailSelectDto Model)
        {
            Collection = await UnitOfWork.SurveyDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<SurveyDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}