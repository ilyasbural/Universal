namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class AnnounceManager : BusinessObject<Announce>, IAnnounceService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Announce> Validator;

        public AnnounceManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Announce> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<Announce>> InsertAsync(AnnounceRegisterDto Model)
        {
            Data = Mapper.Map<Announce>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Announce>(Data);
            await UnitOfWork.Announce.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Announce>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Announce>> UpdateAsync(AnnounceUpdateDto Model)
        {
            Collection = await UnitOfWork.Announce.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Announce>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Announce.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Announce>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Announce>> DeleteAsync(AnnounceDeleteDto Model)
        {
            Collection = await UnitOfWork.Announce.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Announce>(Collection[0]);

            await UnitOfWork.Announce.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Announce>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Announce>> SelectAsync(AnnounceSelectDto Model)
        {
            Collection = await UnitOfWork.Announce.SelectAsync(x => x.IsActive == true);
            return new Response<Announce>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Announce>> SelectSingleAsync(AnnounceSelectDto Model)
        {
            Collection = await UnitOfWork.Announce.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<Announce>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}