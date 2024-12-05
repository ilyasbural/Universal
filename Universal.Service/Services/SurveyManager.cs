namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class SurveyManager : BusinessObject<Survey>, ISurveyService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Survey> Validator;

        public SurveyManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Survey> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<SurveyResponse>> InsertAsync(SurveyRegisterDto Model)
        {
            Data = Mapper.Map<Survey>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Survey>(Data);
            await UnitOfWork.Survey.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyResponse>> UpdateAsync(SurveyUpdateDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Survey>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Survey.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyResponse>> DeleteAsync(SurveyDeleteDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Survey>(Collection[0]);

            await UnitOfWork.Survey.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyResponse>> SelectAsync(SurveySelectDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.IsActive == true);
            return new Response<SurveyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyResponse>> SelectSingleAsync(SurveySelectDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<SurveyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}