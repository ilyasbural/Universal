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

        public async Task<Response<UserAbout>> UpdateAsync(UserAboutUpdateDto Model)
        {
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserAbout>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserAbout.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbout>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbout>> DeleteAsync(UserAboutDeleteDto Model)
        {
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserAbout>(Collection[0]);

            await UnitOfWork.UserAbout.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserAbout>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserAbout>> SelectAsync(UserAbilitySelectDto Model)
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

        public async Task<Response<UserAbout>> SelectSingleAsync(UserAbilitySelectDto Model)
        {
            Collection = await UnitOfWork.UserAbout.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
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