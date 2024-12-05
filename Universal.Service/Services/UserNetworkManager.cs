namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class UserNetworkManager : BusinessObject<UserNetwork>, IUserNetworkService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserNetwork> Validator;

        public UserNetworkManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserNetwork> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserNetworkResponse>> InsertAsync(UserNetworkRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserNetwork>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserNetwork>(Data);
            await UnitOfWork.UserNetwork.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserNetworkResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetworkResponse>> UpdateAsync(UserNetworkUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserNetwork>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserNetwork.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserNetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetworkResponse>> DeleteAsync(UserNetworkDeleteDto Model)
        {
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserNetwork>(Collection[0]);

            await UnitOfWork.UserNetwork.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserNetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetworkResponse>> SelectAsync(UserNetworkSelectDto Model)
        {
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserNetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetworkResponse>> SelectSingleAsync(UserNetworkSelectDto Model)
        {
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserNetworkResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}