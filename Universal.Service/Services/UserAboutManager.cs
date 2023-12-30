namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserAboutManager : BusinessObject<UserAbout>, IUserAboutService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserAbout> Validator;

        public UserAboutManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserAbout> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserAbout>> InsertAsync(UserAboutRegisterDto Model)
        {
            Data = Mapper.Map<UserAbout>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserAbout>(Data);
            await UnitOfWork.UserAbout.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbout>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbout>> SelectAsync()
        {
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.IsActive == true);
            return new Response<UserAbout>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}