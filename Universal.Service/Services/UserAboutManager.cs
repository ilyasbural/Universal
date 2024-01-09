namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserAboutManager : BusinessObject<UserAbout>, IUserAboutService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserAbout> Validator;

        public UserAboutManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserAbout> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserAbout>> InsertAsync(UserAboutRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserAbout>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.About = Model.About;
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserAbout>(Data);
            await UnitOfWork.UserAbout.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbout>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbout>> UpdateAsync(UserAboutUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserAbout>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.About = Model.About;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserAbout.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbout>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbout>> DeleteAsync(UserAboutDeleteDto Model)
        {
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserAbout>(Collection[0]);

            await UnitOfWork.UserAbout.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbout>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbout>> SelectAsync(UserAbilitySelectDto Model)
        {
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserAbout>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbout>> SelectSingleAsync(UserAbilitySelectDto Model)
        {
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserAbout>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}