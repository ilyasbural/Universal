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

        public Task<Response<UserType>> DeleteAsync(UserTypeDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserType>> InsertAsync(UserTypeRegisterDto Model)
        {
            Data = Mapper.Map<UserType>(Model);
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

        public async Task<Response<UserType>> SelectAsync()
        {
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.IsActive == true);
            return new Response<UserType>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserType>> SelectAsync(UserTypeSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserType>> SelectSingleAsync(UserTypeSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserType>> UpdateAsync(UserTypeUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}