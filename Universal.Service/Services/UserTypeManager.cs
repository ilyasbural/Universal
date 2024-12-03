namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserTypeManager : BusinessObject<UserType>, IUserTypeService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserType> Validator;

        public UserTypeManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserType> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserType>> InsertAsync(UserTypeRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserType>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserType>(Data);
            await UnitOfWork.UserType.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserType>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserType>> UpdateAsync(UserTypeUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserType>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserType.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserType>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserType>> DeleteAsync(UserTypeDeleteDto Model)
        {
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserType>(Collection[0]);

            await UnitOfWork.UserType.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserType>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserType>> SelectAsync(UserTypeSelectDto Model)
        {
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserType>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserType>> SelectSingleAsync(UserTypeSelectDto Model)
        {
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserType>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}