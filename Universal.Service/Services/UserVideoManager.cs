namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class UserVideoManager : BusinessObject<UserVideo>, IUserVideoService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserVideo> Validator;

        public UserVideoManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserVideo> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserVideoResponse>> InsertAsync(UserVideoRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserVideo>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserVideo>(Data);
            await UnitOfWork.UserVideo.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserVideoResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserVideoResponse>> UpdateAsync(UserVideoUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserVideo.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserVideo>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserVideo.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserVideoResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserVideoResponse>> DeleteAsync(UserVideoDeleteDto Model)
        {
            Collection = await UnitOfWork.UserVideo.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserVideo>(Collection[0]);

            await UnitOfWork.UserVideo.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserVideoResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserVideoResponse>> SelectAsync(UserVideoSelectDto Model)
        {
            Collection = await UnitOfWork.UserVideo.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserVideoResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserVideoResponse>> SelectSingleAsync(UserVideoSelectDto Model)
        {
            Collection = await UnitOfWork.UserVideo.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserVideoResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}