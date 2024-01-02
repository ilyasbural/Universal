namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class PositionManager : BusinessObject<Position>, IPositionService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Position> Validator;

        public PositionManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Position> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<Position>> DeleteAsync(PositionDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Position>> InsertAsync(PositionRegisterDto Model)
        {
            Data = Mapper.Map<Position>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Position>(Data);
            await UnitOfWork.Position.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Position>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Position>> SelectAsync()
        {
            Collection = await UnitOfWork.Position.SelectAsync(x => x.IsActive == true);
            return new Response<Position>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<Position>> SelectAsync(PositionSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Position>> SelectSingleAsync(PositionSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Position>> UpdateAsync(PositionUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}