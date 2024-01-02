namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserDetailManager : BusinessObject<UserDetail>, IUserDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserDetail> Validator;

        public UserDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<UserDetail>> DeleteAsync(UserDetailDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserDetail>> InsertAsync(UserDetailRegisterDto Model)
        {
            Data = Mapper.Map<UserDetail>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserDetail>(Data);
            await UnitOfWork.UserDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserDetail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserDetail>> SelectAsync()
        {
            Collection = await UnitOfWork.UserDetail.SelectAsync(x => x.IsActive == true);
            return new Response<UserDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserDetail>> SelectAsync(UserDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserDetail>> SelectSingleAsync(UserDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserDetail>> UpdateAsync(UserDetailUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}