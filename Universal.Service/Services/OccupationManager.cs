namespace Universal.Service
{
    using Core;
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

        public Task<Response<Occupation>> DeleteAsync(OccupationDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Occupation>> InsertAsync(OccupationRegisterDto Model)
        {
            Data = Mapper.Map<Occupation>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Occupation>(Data);
            await UnitOfWork.Occupation.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Occupation>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Occupation>> SelectAsync()
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.IsActive == true);
            return new Response<Occupation>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<Occupation>> SelectAsync(OccupationSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Occupation>> SelectSingleAsync(OccupationSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Occupation>> UpdateAsync(OccupationUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}