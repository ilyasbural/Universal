namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class SurveyHistoryManager : BusinessObject<SurveyHistory>, ISurveyHistoryService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<SurveyHistory> Validator;

        public SurveyHistoryManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<SurveyHistory> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<SurveyHistory>> InsertAsync(SurveyHistoryRegisterDto Model)
        {
            Data = Mapper.Map<SurveyHistory>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<SurveyHistory>(Data);
            await UnitOfWork.SurveyHistory.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyHistory>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyHistory>> SelectAsync()
        {
            Collection = await UnitOfWork.SurveyHistory.SelectAsync(x => x.IsActive == true);
            return new Response<SurveyHistory>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}