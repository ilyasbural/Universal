namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class AnnounceDetailManager : BusinessObject<AnnounceDetail>, IAnnounceDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<AnnounceDetail> Validator;

        public AnnounceDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<AnnounceDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }     

        public async Task<Response<AnnounceDetail>> InsertAsync(AnnounceDetailRegisterDto Model)
        {
            Data = Mapper.Map<AnnounceDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<AnnounceDetail>(Data);
            await UnitOfWork.AnnounceDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<AnnounceDetail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<AnnounceDetail>> UpdateAsync(AnnounceDetailUpdateDto Model)
        {
            Collection = await UnitOfWork.AnnounceDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<AnnounceDetail>(Collection[0]);
            Data.Description = Model.Description;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.AnnounceDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<AnnounceDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<AnnounceDetail>> DeleteAsync(AnnounceDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.AnnounceDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<AnnounceDetail>(Collection[0]);

            await UnitOfWork.AnnounceDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<AnnounceDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<AnnounceDetail>> SelectAsync(AnnounceDetailSelectDto Model)
        {
            Collection = await UnitOfWork.AnnounceDetail.SelectAsync(x => x.IsActive == true);
            return new Response<AnnounceDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<AnnounceDetail>> SelectSingleAsync(AnnounceDetailSelectDto Model)
        {
            Collection = await UnitOfWork.AnnounceDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<AnnounceDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}