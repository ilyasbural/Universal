namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<RegionResponse>> InsertAsync(RegionRegisterDto Model)
        {
            Data = Mapper.Map<Region>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Region>(Data);
            await UnitOfWork.Region.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<RegionResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<RegionResponse>> UpdateAsync(RegionUpdateDto Model)
        {
            Collection = await UnitOfWork.Region.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Region>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Region.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<RegionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<RegionResponse>> DeleteAsync(RegionDeleteDto Model)
        {
            Collection = await UnitOfWork.Region.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Region>(Collection[0]);

            await UnitOfWork.Region.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<RegionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<RegionResponse>> SelectAsync(RegionSelectDto Model)
        {
            Collection = await UnitOfWork.Region.SelectAsync(x => x.IsActive == true);
            return new Response<RegionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<RegionResponse>> SelectSingleAsync(RegionSelectDto Model)
        {
            Collection = await UnitOfWork.Region.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<RegionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}