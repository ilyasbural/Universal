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

        public Task<Response<UserNetwork>> DeleteAsync(UserNetworkDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserNetwork>> InsertAsync(UserNetworkRegisterDto Model)
        {
            Data = Mapper.Map<UserNetwork>(Model);
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

        public async Task<Response<UserNetwork>> SelectAsync()
        {
            Collection = await UnitOfWork.UserNetwork.SelectAsync(x => x.IsActive == true);
            return new Response<UserNetwork>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserNetwork>> SelectAsync(UserNetworkSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserNetwork>> SelectSingleAsync(UserNetworkSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserNetwork>> UpdateAsync(UserNetworkUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}