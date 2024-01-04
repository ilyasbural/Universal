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

        public async Task<Response<UserType>> UpdateAsync(UserTypeUpdateDto Model)
        {
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserType>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserType.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserType>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserType>> DeleteAsync(UserTypeDeleteDto Model)
        {
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserType>(Collection[0]);

            await UnitOfWork.UserType.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserType>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserType>> SelectAsync(UserTypeSelectDto Model)
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

        public async Task<Response<UserType>> SelectSingleAsync(UserTypeSelectDto Model)
        {
            Collection = await UnitOfWork.UserType.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<UserType>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}