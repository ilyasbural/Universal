namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class SurveyLogManager : BusinessObject<SurveyLog>, ISurveyLogService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<SurveyLog> Validator;

        public SurveyLogManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<SurveyLog> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<SurveyLog>> DeleteAsync(SurveyLogDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<SurveyLog>> InsertAsync(SurveyLogRegisterDto Model)
        {
            Data = Mapper.Map<SurveyLog>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<SurveyLog>(Data);
            await UnitOfWork.SurveyLog.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyLog>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyLog>> SelectAsync()
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.IsActive == true);
            return new Response<SurveyLog>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<SurveyLog>> SelectAsync(SurveyLogSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SurveyLog>> SelectSingleAsync(SurveyLogSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SurveyLog>> UpdateAsync(SurveyLogUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}