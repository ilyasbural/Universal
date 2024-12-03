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
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserExperience>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
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

        public async Task<Response<UserExperience>> UpdateAsync(UserExperienceUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserExperience.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserExperience>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserExperience.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserExperience>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserExperience>> DeleteAsync(UserExperienceDeleteDto Model)
        {
            Collection = await UnitOfWork.UserExperience.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserExperience>(Collection[0]);

            await UnitOfWork.UserExperience.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserExperience>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserExperience>> SelectAsync(UserExperienceSelectDto Model)
        {
            Collection = await UnitOfWork.UserExperience.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserExperience>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserExperience>> SelectSingleAsync(UserExperienceSelectDto Model)
        {
            Collection = await UnitOfWork.UserExperience.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
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