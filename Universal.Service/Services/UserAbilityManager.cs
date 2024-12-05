namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<UserAbilityResponse>> InsertAsync(UserAbilityRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            List<Ability> AbilityList = await UnitOfWork.Ability.SelectAsync(x => x.Id == Model.AbilityId);

            Data = Mapper.Map<UserAbility>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Ability = AbilityList.FirstOrDefault(x => x.Id == Model.AbilityId) ?? new Ability();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserAbility>(Data);
            await UnitOfWork.UserAbility.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbilityResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbilityResponse>> UpdateAsync(UserAbilityUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            List<Ability> AbilityList = await UnitOfWork.Ability.SelectAsync(x => x.Id == Model.AbilityId);
            Collection = await UnitOfWork.UserAbility.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserAbility>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Ability = AbilityList.FirstOrDefault(x => x.Id == Model.AbilityId) ?? new Ability();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserAbility.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbilityResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbilityResponse>> DeleteAsync(UserAbilityDeleteDto Model)
        {
            Collection = await UnitOfWork.UserAbility.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserAbility>(Collection[0]);

            await UnitOfWork.UserAbility.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbilityResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbilityResponse>> SelectAsync(UserAbilitySelectDto Model)
        {
            Collection = await UnitOfWork.UserAbility.SelectAsync(x => x.IsActive == true, x => x.User, x => x.Ability);
            return new Response<UserAbilityResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbilityResponse>> SelectSingleAsync(UserAbilitySelectDto Model)
        {
            Collection = await UnitOfWork.UserAbility.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User, x => x.Ability);
            return new Response<UserAbilityResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}