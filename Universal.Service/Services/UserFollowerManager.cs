namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class UserFollowerManager : BusinessObject<UserFollower>, IUserFollowerService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserFollower> Validator;

        public UserFollowerManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserFollower> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserFollowerResponse>> InsertAsync(UserFollowerRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserFollower>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserFollower>(Data);
            await UnitOfWork.UserFollower.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserFollowerResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserFollowerResponse>> UpdateAsync(UserFollowerUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserFollower.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserFollower>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserFollower.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserFollowerResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserFollowerResponse>> DeleteAsync(UserFollowerDeleteDto Model)
        {
            Collection = await UnitOfWork.UserFollower.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserFollower>(Collection[0]);

            await UnitOfWork.UserFollower.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserFollowerResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserFollowerResponse>> SelectAsync(UserFollowerSelectDto Model)
        {
            Collection = await UnitOfWork.UserFollower.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserFollowerResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserFollowerResponse>> SelectSingleAsync(UserFollowerSelectDto Model)
        {
            Collection = await UnitOfWork.UserFollower.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserFollowerResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}