namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserCountryManager : BusinessObject<UserCountry>, IUserCountryService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserCountry> Validator;

        public UserCountryManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserCountry> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserCountry>> InsertAsync(UserCountryRegisterDto Model)
        {
            Data = Mapper.Map<UserCountry>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserCountry>(Data);
            await UnitOfWork.UserCountry.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserCountry>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserCountry>> UpdateAsync(UserCountryUpdateDto Model)
        {
            Collection = await UnitOfWork.UserCountry.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserCountry>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserCountry.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserCountry>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserCountry>> DeleteAsync(UserCountryDeleteDto Model)
        {
            Collection = await UnitOfWork.UserCountry.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserCountry>(Collection[0]);

            await UnitOfWork.UserCountry.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserCountry>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserCountry>> SelectAsync(UserCountrySelectDto Model)
        {
            Collection = await UnitOfWork.UserCountry.SelectAsync(x => x.IsActive == true);
            return new Response<UserCountry>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserCountry>> SelectSingleAsync(UserCountrySelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}