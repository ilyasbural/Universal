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
    }
}