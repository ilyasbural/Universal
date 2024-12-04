namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<CountryResponse>> InsertAsync(CountryRegisterDto Model)
        {
            Data = Mapper.Map<Country>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Country>(Data);
            await UnitOfWork.Country.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CountryResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        } 

        public async Task<Response<CountryResponse>> UpdateAsync(CountryUpdateDto Model)
        {
            Collection = await UnitOfWork.Country.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Country>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Country.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CountryResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CountryResponse>> DeleteAsync(CountryDeleteDto Model)
        {
            Collection = await UnitOfWork.Country.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Country>(Collection[0]);

            await UnitOfWork.Country.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CountryResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CountryResponse>> SelectAsync(CountrySelectDto Model)
        {
            Collection = await UnitOfWork.Country.SelectAsync(x => x.IsActive == true);
            return new Response<CountryResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<CountryResponse>> SelectSingleAsync(CountrySelectDto Model)
        {
            Collection = await UnitOfWork.Country.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<CountryResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}