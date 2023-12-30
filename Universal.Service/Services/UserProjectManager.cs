namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserProjectManager : BusinessObject<UserProject>, IUserProjectService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserProject> Validator;

        public UserProjectManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserProject> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserProject>> InsertAsync(UserProjectRegisterDto Model)
        {
            Data = Mapper.Map<UserProject>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserProject>(Data);
            await UnitOfWork.UserProject.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserProject>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserProject>> SelectAsync()
        {
            Collection = await UnitOfWork.UserProject.SelectAsync(x => x.IsActive == true);
            return new Response<UserProject>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}