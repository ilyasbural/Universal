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
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);

            Data = Mapper.Map<UserProject>(Model);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
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

        public async Task<Response<UserProject>> UpdateAsync(UserProjectUpdateDto Model)
        {
            List<User> UserList = await UnitOfWork.User.SelectAsync(x => x.Id == Model.UserId);
            Collection = await UnitOfWork.UserProject.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserProject>(Collection[0]);
            Data.User = UserList.FirstOrDefault(x => x.Id == Model.UserId) ?? new User();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserProject.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserProject>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserProject>> DeleteAsync(UserProjectDeleteDto Model)
        {
            Collection = await UnitOfWork.UserProject.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserProject>(Collection[0]);

            await UnitOfWork.UserProject.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserProject>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserProject>> SelectAsync(UserProjectSelectDto Model)
        {
            Collection = await UnitOfWork.UserProject.SelectAsync(x => x.IsActive == true, x => x.User);
            return new Response<UserProject>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserProject>> SelectSingleAsync(UserProjectSelectDto Model)
        {
            Collection = await UnitOfWork.UserProject.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.User);
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