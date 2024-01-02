namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class RegionManager : BusinessObject<Region>, IRegionService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Region> Validator;

        public RegionManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Region> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<Region>> DeleteAsync(RegionDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Region>> InsertAsync(RegionRegisterDto Model)
        {
            Data = Mapper.Map<Region>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Region>(Data);
            await UnitOfWork.Region.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Region>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Region>> SelectAsync()
        {
            Collection = await UnitOfWork.Region.SelectAsync(x => x.IsActive == true);
            return new Response<Region>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<Region>> SelectAsync(RegionSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Region>> SelectSingleAsync(RegionSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Region>> UpdateAsync(RegionUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}