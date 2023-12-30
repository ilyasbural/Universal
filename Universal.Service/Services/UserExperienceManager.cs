namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserExperienceManager : BusinessObject<UserExperience>, IUserExperienceService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserExperience> Validator;

        public UserExperienceManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserExperience> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserExperience>> InsertAsync(UserExperienceRegisterDto Model)
        {
            Data = Mapper.Map<UserExperience>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserExperience>(Data);
            await UnitOfWork.UserExperience.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserExperience>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserExperience>> SelectAsync()
        {
            Collection = await UnitOfWork.UserExperience.SelectAsync(x => x.IsActive == true);
            return new Response<UserExperience>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}