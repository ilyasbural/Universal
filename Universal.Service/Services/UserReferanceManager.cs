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
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserReferance>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
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
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserReferance.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserReferance>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
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

        public async Task<Response<UserReferance>> DeleteAsync(UserReferanceDeleteDto Model)
        {
            Collection = await UnitOfWork.UserReferance.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserReferance>(Collection[0]);

            await UnitOfWork.UserReferance.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserReferance>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserReferance>> SelectAsync(UserReferanceSelectDto Model)
        {
            Collection = await UnitOfWork.UserReferance.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserReferance>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserReferance>> SelectSingleAsync(UserReferanceSelectDto Model)
        {
            Collection = await UnitOfWork.UserReferance.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserReferance>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}