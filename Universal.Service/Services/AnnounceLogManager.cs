namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class AnnounceLogManager : BusinessObject<AnnounceLog>, IAnnounceLogService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<AnnounceLog> Validator;

        public AnnounceLogManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<AnnounceLog> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<AnnounceLog>> DeleteAsync(AnnounceLogDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<AnnounceLog>> InsertAsync(AnnounceLogRegisterDto Model)
        {
            Data = Mapper.Map<AnnounceLog>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<AnnounceLog>(Data);
            await UnitOfWork.AnnounceLog.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<AnnounceLog>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<AnnounceLog>> SelectAsync()
        {
            Collection = await UnitOfWork.AnnounceLog.SelectAsync(x => x.IsActive == true);
            return new Response<AnnounceLog>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<AnnounceLog>> SelectAsync(AnnounceLogSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AnnounceLog>> SelectSingleAsync(AnnounceLogSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AnnounceLog>> UpdateAsync(AnnounceLogUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}