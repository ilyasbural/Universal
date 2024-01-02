namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserManager : BusinessObject<User>, IUserService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<User> Validator;

        public UserManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<User> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<User>> InsertAsync(UserRegisterDto Model)
        {
            Data = Mapper.Map<User>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<User>(Data);
            await UnitOfWork.User.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<User>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }
        
        public Task<Response<User>> UpdateAsync(UserUpdateDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<User>> DeleteAsync(UserDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<User>> SelectAsync(UserSelectDto Model)
        {
            Collection = await UnitOfWork.User.SelectAsync(x => x.IsActive == true);
            return new Response<User>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<User>> SelectSingleAsync(UserSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}