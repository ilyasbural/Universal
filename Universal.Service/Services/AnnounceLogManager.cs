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

        public async Task<Response<AnnounceLog>> UpdateAsync(AnnounceLogUpdateDto Model)
        {
            Collection = await UnitOfWork.AnnounceLog.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<AnnounceLog>(Collection[0]);
            Data.Note = Model.Note;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.AnnounceLog.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<AnnounceLog>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<AnnounceLog>> DeleteAsync(AnnounceLogDeleteDto Model)
        {
            Collection = await UnitOfWork.AnnounceLog.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<AnnounceLog>(Collection[0]);

            await UnitOfWork.AnnounceLog.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<AnnounceLog>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<AnnounceLog>> SelectAsync(AnnounceLogSelectDto Model)
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

        public async Task<Response<AnnounceLog>> SelectSingleAsync(AnnounceLogSelectDto Model)
        {
            Collection = await UnitOfWork.AnnounceLog.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<AnnounceLog>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}