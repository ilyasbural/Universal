namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<SurveyLogResponse>> InsertAsync(SurveyLogRegisterDto Model)
        {
            Data = Mapper.Map<SurveyLog>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<SurveyLog>(Data);
            await UnitOfWork.SurveyLog.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyLogResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyLogResponse>> UpdateAsync(SurveyLogUpdateDto Model)
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyLog>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.SurveyLog.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyLogResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyLogResponse>> DeleteAsync(SurveyLogDeleteDto Model)
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyLog>(Collection[0]);

            await UnitOfWork.SurveyLog.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyLogResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyLogResponse>> SelectAsync(SurveyLogSelectDto Model)
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.IsActive == true);
            return new Response<SurveyLogResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyLogResponse>> SelectSingleAsync(SurveyLogSelectDto Model)
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<SurveyLogResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}