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

        public Task<Response<Announce>> DeleteAsync(AnnounceDeleteDto Model)
        {
            throw new NotImplementedException();
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

        public async Task<Response<Announce>> SelectAsync()
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

        public Task<Response<Announce>> SelectAsync(AnnounceSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Announce>> SelectSingleAsync(AnnounceSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Announce>> UpdateAsync(AnnounceUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}