namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserAbilityManager : BusinessObject<UserAbility>, IUserAbilityService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserAbility> Validator;

        public UserAbilityManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserAbility> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<UserAbility>> DeleteAsync(UserAbilityDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserAbility>> InsertAsync(UserAbilityRegisterDto Model)
        {
            Data = Mapper.Map<UserAbility>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserAbility>(Data);
            await UnitOfWork.UserAbility.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbility>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbility>> SelectAsync()
        {
            Collection = await UnitOfWork.UserAbility.SelectAsync(x => x.IsActive == true);
            return new Response<UserAbility>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserAbility>> SelectAsync(UserAbilitySelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserAbility>> SelectSingleAsync(UserAbilitySelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserAbility>> UpdateAsync(UserAbilityUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}