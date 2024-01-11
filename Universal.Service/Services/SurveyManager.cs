namespace Universal.Service
{
    using Core;
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

        public async Task<Response<Survey>> InsertAsync(SurveyRegisterDto Model)
        {
            Data = Mapper.Map<Survey>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Survey>(Data);
            await UnitOfWork.Survey.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Survey>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Survey>> UpdateAsync(SurveyUpdateDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Survey>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Survey.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Survey>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Survey>> DeleteAsync(SurveyDeleteDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Survey>(Collection[0]);

            await UnitOfWork.Survey.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Survey>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Survey>> SelectAsync(SurveySelectDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.IsActive == true);
            return new Response<Survey>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Survey>> SelectSingleAsync(SurveySelectDto Model)
        {
            Collection = await UnitOfWork.Survey.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<Survey>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}