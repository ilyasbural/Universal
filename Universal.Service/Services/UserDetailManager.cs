namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class UserDetailManager : BusinessObject<UserDetail>, IUserDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserDetail> Validator;

        public UserDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserDetailResponse>> InsertAsync(UserDetailRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserDetail>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserDetail>(Data);
            await UnitOfWork.UserDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserDetailResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserDetailResponse>> UpdateAsync(UserDetailUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserDetail>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserDetailResponse>> DeleteAsync(UserDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.UserDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserDetail>(Collection[0]);

            await UnitOfWork.UserDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserDetailResponse>> SelectAsync(UserDetailSelectDto Model)
        {
            Collection = await UnitOfWork.UserDetail.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserDetailResponse>> SelectSingleAsync(UserDetailSelectDto Model)
        {
            Collection = await UnitOfWork.UserDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserDetailResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}