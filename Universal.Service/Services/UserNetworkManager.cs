namespace Universal.Service
{
    using Core;
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

        public async Task<Response<UserNetwork>> InsertAsync(UserNetworkRegisterDto Model)
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

            return new Response<UserNetwork>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetwork>> UpdateAsync(UserNetworkUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserNetwork>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserNetwork.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserNetwork>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetwork>> DeleteAsync(UserNetworkDeleteDto Model)
        {
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserNetwork>(Collection[0]);

            await UnitOfWork.UserNetwork.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserNetwork>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetwork>> SelectAsync(UserNetworkSelectDto Model)
        {
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserNetwork>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserNetwork>> SelectSingleAsync(UserNetworkSelectDto Model)
        {
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserNetwork>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}