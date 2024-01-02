namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserReferanceManager : BusinessObject<UserReferance>, IUserReferanceService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserReferance> Validator;

        public UserReferanceManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserReferance> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserReferance>> InsertAsync(UserReferanceRegisterDto Model)
        {
            Data = Mapper.Map<UserReferance>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserReferance>(Data);
            await UnitOfWork.UserReferance.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserReferance>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserReferance>> UpdateAsync(UserReferanceUpdateDto Model)
        {
            Collection = await UnitOfWork.UserReferance.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserReferance>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserReferance.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserReferance>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserReferance>> DeleteAsync(UserReferanceDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserReferance>> SelectAsync(UserReferanceSelectDto Model)
        {
            Collection = await UnitOfWork.UserReferance.SelectAsync(x => x.IsActive == true);
            return new Response<UserReferance>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserReferance>> SelectSingleAsync(UserReferanceSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}