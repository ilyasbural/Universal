namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<UserResponse>> InsertAsync(UserRegisterDto Model)
        {
            Data = Mapper.Map<User>(Model);
            Data.Id = Guid.NewGuid();
            Data.Email = Model.Email;
            Data.Password = Model.Password;
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;
            Validator.ValidateAndThrow<User>(Data);

            await UnitOfWork.User.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }
        
        public async Task<Response<UserResponse>> UpdateAsync(UserUpdateDto Model)
        {
            Collection = await UnitOfWork.User.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<User>(Collection[0]);
            Data.Email = Model.Email;
            Data.Password = Model.Password;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.User.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserResponse>> DeleteAsync(UserDeleteDto Model)
        {
            Collection = await UnitOfWork.User.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<User>(Collection[0]);

            await UnitOfWork.User.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserResponse>> SelectAsync(UserSelectDto Model)
        {
            Collection = await UnitOfWork.User.SelectAsync(x => x.IsActive == true);
            foreach (User user in Collection)
            {
                
            }

			return new Response<UserResponse>
            {


    //            Data = new UserResponse
    //            {



    //            },
				//Message = "Success",
				//Success = 1,
				//IsValidationError = false
            };
        }

        public async Task<Response<UserResponse>> SelectSingleAsync(UserSelectDto Model)
        {
            Collection = await UnitOfWork.User.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<UserResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}