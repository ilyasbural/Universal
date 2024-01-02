namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class CountryManager : BusinessObject<Country>, ICountryService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Country> Validator;

        public CountryManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Country> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<Country>> DeleteAsync(CountryDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Country>> InsertAsync(CountryRegisterDto Model)
        {
            Data = Mapper.Map<Country>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Country>(Data);
            await UnitOfWork.Country.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Country>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Country>> SelectAsync()
        {
            Collection = await UnitOfWork.Country.SelectAsync(x => x.IsActive == true);
            return new Response<Country>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<Country>> SelectAsync(CountrySelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Country>> SelectSingleAsync(CountrySelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Country>> UpdateAsync(CountryUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}