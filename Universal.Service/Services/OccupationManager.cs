namespace Universal.Service
{
    using Core;
    using Common;
    using AutoMapper;
    using FluentValidation;

    public class OccupationManager : BusinessObject<Occupation>, IOccupationService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Occupation> Validator;

        public OccupationManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Occupation> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<OccupationResponse>> InsertAsync(OccupationRegisterDto Model)
        {
            Data = Mapper.Map<Occupation>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Occupation>(Data);
            await UnitOfWork.Occupation.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<OccupationResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<OccupationResponse>> UpdateAsync(OccupationUpdateDto Model)
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Occupation>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Occupation.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<OccupationResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<OccupationResponse>> DeleteAsync(OccupationDeleteDto Model)
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Occupation>(Collection[0]);

            await UnitOfWork.Occupation.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<OccupationResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<OccupationResponse>> SelectAsync(OccupationSelectDto Model)
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.IsActive == true);
            return new Response<OccupationResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<OccupationResponse>> SelectSingleAsync(OccupationSelectDto Model)
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<OccupationResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}