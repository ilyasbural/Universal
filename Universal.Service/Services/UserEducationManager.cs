namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserEducationManager : BusinessObject<UserEducation>, IUserEducationService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserEducation> Validator;

        public UserEducationManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserEducation> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserEducation>> InsertAsync(UserEducationRegisterDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserEducation>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserEducation>(Data);
            await UnitOfWork.UserEducation.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserEducation>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }   

        public async Task<Response<UserEducation>> UpdateAsync(UserEducationUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserEducation>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserEducation.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserEducation>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserEducation>> DeleteAsync(UserEducationDeleteDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserEducation>(Collection[0]);

            await UnitOfWork.UserEducation.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserEducation>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserEducation>> SelectAsync(UserEducationSelectDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserEducation>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserEducation>> SelectSingleAsync(UserEducationSelectDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
            return new Response<UserEducation>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}