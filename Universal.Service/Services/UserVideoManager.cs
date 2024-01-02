namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserVideoManager : BusinessObject<UserVideo>, IUserVideoService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserVideo> Validator;

        public UserVideoManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserVideo> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<UserVideo>> DeleteAsync(UserVideoDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserVideo>> InsertAsync(UserVideoRegisterDto Model)
        {
            Data = Mapper.Map<UserVideo>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserVideo>(Data);
            await UnitOfWork.UserVideo.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserVideo>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserVideo>> SelectAsync()
        {
            Collection = await UnitOfWork.UserVideo.SelectAsync(x => x.IsActive == true);
            return new Response<UserVideo>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserVideo>> SelectAsync(UserVideoSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserVideo>> SelectSingleAsync(UserVideoSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserVideo>> UpdateAsync(UserVideoUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}