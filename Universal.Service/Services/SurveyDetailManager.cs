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

        public Task<Response<SurveyDetail>> DeleteAsync(SurveyDetailDeleteDto Model)
        {
            throw new NotImplementedException();
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

        public async Task<Response<SurveyDetail>> SelectAsync()
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

        public Task<Response<SurveyDetail>> SelectAsync(SurveyDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SurveyDetail>> SelectSingleAsync(SurveyDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SurveyDetail>> UpdateAsync(SurveyDetailUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}