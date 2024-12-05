namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<PositionResponse>> InsertAsync(PositionRegisterDto Model)
        {
            Data = Mapper.Map<Position>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Position>(Data);
            await UnitOfWork.Position.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<PositionResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<PositionResponse>> UpdateAsync(PositionUpdateDto Model)
        {
            Collection = await UnitOfWork.Position.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Position>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Position.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<PositionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<PositionResponse>> DeleteAsync(PositionDeleteDto Model)
        {
            Collection = await UnitOfWork.Position.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Position>(Collection[0]);

            await UnitOfWork.Position.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<PositionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<PositionResponse>> SelectAsync(PositionSelectDto Model)
        {
            Collection = await UnitOfWork.Position.SelectAsync(x => x.IsActive == true);
            return new Response<PositionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<PositionResponse>> SelectSingleAsync(PositionSelectDto Model)
        {
            Collection = await UnitOfWork.Position.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<PositionResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}