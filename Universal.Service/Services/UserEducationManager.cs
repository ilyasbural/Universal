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
            Data = Mapper.Map<UserEducation>(Model);
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

        public Task<Response<UserEducation>> UpdateAsync(UserEducationUpdateDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserEducation>> DeleteAsync(UserEducationDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserEducation>> SelectAsync(UserEducationSelectDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.IsActive == true);
            return new Response<UserEducation>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<UserEducation>> SelectSingleAsync(UserEducationSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}