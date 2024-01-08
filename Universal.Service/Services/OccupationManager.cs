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

        public async Task<Response<Occupation>> UpdateAsync(OccupationUpdateDto Model)
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Occupation>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Occupation.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Occupation>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Occupation>> DeleteAsync(OccupationDeleteDto Model)
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Occupation>(Collection[0]);

            await UnitOfWork.Occupation.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Occupation>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Occupation>> SelectAsync(OccupationSelectDto Model)
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

        public async Task<Response<Occupation>> SelectSingleAsync(OccupationSelectDto Model)
        {
            Collection = await UnitOfWork.Occupation.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<Occupation>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}