namespace Universal.Service
{
    using Core;
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

        public async Task<Response<UserFollower>> InsertAsync(UserFollowerRegisterDto Model)
        {
            Data = Mapper.Map<UserFollower>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserFollower>(Data);
            await UnitOfWork.UserFollower.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserFollower>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserFollower>> SelectAsync()
        {
            Collection = await UnitOfWork.UserFollower.SelectAsync(x => x.IsActive == true);
            return new Response<UserFollower>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}