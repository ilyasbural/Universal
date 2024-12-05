namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class UserPublishManager : BusinessObject<UserPublish>, IUserPublishService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserPublish> Validator;

        public UserPublishManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserPublish> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserPublishResponse>> InsertAsync(UserPublishRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserPublish>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserPublish>(Data);
            await UnitOfWork.UserPublish.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserPublishResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublishResponse>> UpdateAsync(UserPublishUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserPublish>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserPublish.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserPublishResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublishResponse>> DeleteAsync(UserPublishDeleteDto Model)
        {
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserPublish>(Collection[0]);

            await UnitOfWork.UserPublish.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserPublishResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublishResponse>> SelectAsync(UserPublishSelectDto Model)
        {
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserPublishResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublishResponse>> SelectSingleAsync(UserPublishSelectDto Model)
        {
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserPublishResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}