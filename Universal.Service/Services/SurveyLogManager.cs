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

        public async Task<Response<SurveyLog>> UpdateAsync(SurveyLogUpdateDto Model)
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyLog>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.SurveyLog.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyLog>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyLog>> DeleteAsync(SurveyLogDeleteDto Model)
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<SurveyLog>(Collection[0]);

            await UnitOfWork.SurveyLog.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<SurveyLog>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<SurveyLog>> SelectAsync(SurveyLogSelectDto Model)
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

        public async Task<Response<SurveyLog>> SelectSingleAsync(SurveyLogSelectDto Model)
        {
            Collection = await UnitOfWork.SurveyLog.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<SurveyLog>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}